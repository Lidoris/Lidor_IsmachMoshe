using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mailManager = new MailManager();
            TimerCallback tcb = new TimerCallback(mailManager.SimulateMailArrived);

            mailManager.MailArrived += MailManager_MailArrived;
            Timer timer = new Timer( tcb , null , 0, 1000);
            Console.ReadLine();
        }

        public static void MailManager_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine(e.Title);
            Console.WriteLine(e.Body);
        }
    }
}
