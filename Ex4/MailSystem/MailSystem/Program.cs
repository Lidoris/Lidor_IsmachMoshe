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

            mailManager.MailArrived += MailManager_MailArrived;
            mailManager.SimulateMailArrived(); //Create a System.Threading.Timer, and in the timer callback call SimulateMailArrived every 1 second
            
        }

        public static void MailManager_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine(e.Title);
            Console.WriteLine(e.Body);
        }
    }
}
