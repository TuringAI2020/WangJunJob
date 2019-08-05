using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangJun.Yun;

namespace WangJun.JobProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            WangJunJob.GetInst().StartJob("Job1","T1",3,10);
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(20*1000);
                WangJunJob.GetInst().StopJob("Job1");
            });
            Console.ReadKey();
        }
    }
}
