using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailManager
    {
        public delegate void EventHandler<T>(object sender, T e) where T : MailArrivedEventArgs;
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        
        public void SimulateMailArrived(object obj)
        {
            OnMailArrived(new MailArrivedEventArgs("Title for the mail", "Body for the mail "));
        }

        protected virtual void OnMailArrived(MailArrivedEventArgs args)
        {
            if (MailArrived!= null)
            {
                MailArrived(this, args);
            }

        }
    }
}
