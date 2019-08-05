using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace WangJun.Yun
{
    public class MailJob:WangJunJob,IJob
    {
        public override Task Execute(IJobExecutionContext context)
        {
            var task = new Task(() =>
            {
                WangJunMail.GetInst("smtp.163.com", 25, false, "tushu2019", "7573Wj7573").Send("tushu2019@163.com", "tushu2019@163.com", $"汪俊定时作业{DateTime.Now.ToString("yyyyMMddHHmm")}", $"汪俊定时作业{DateTime.Now}");
            });
            task.Start();
            return task;

        }
    }
}
