using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace WangJun.Yun
{
    public class WangJunJob : IJob
    {
        protected StdSchedulerFactory factory  ;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WangJunJob GetInst()
        {
            var inst = new WangJunJob();
            inst.factory = new StdSchedulerFactory();
            return inst;
        }

        public RES StartJob<T>(string jobName,string triggerName,int interval , int repeatCount) where T : IJob
        {
            try
            {
                 
                var scheduler = this.factory.GetScheduler();

                var jobDetail = JobBuilder.Create<T>().WithIdentity(jobName).Build();
                var trigger = TriggerBuilder.Create().WithIdentity(triggerName).WithSimpleSchedule(p => p.WithIntervalInSeconds(interval).WithRepeatCount(repeatCount)).Build();
                scheduler.Result.ScheduleJob(jobDetail, trigger);
                scheduler.Result.Start();
                return RES.OK();
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message, ex.Message);
            }
        }

        public RES StopJob(string jobName)
        {
            try
            {
                var scheduler = this.factory.GetScheduler();
                scheduler.Result.DeleteJob(new JobKey(jobName));
                return RES.OK();
            }
            catch (Exception ex)
            {
                return RES.FAIL(ex.Message, ex.Message);
            }
        }

        public virtual Task Execute(IJobExecutionContext context)
        {
            var task = new Task(() =>
            {
                Console.WriteLine($"Greetings from HelloJob! {context.RefireCount}");
            });
            task.Start();
            return task;
        }
    }
}
