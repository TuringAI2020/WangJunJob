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
            WangJunJob.GetInst().StartJob<MailJob>("JobMail","TMail",3600,24);
 
            Console.ReadKey();
        }
    }
}
