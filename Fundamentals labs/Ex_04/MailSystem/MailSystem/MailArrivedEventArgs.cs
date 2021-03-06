﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {
        public string Title { get; private set; }
        public string Body { get; private set; }

        public MailArrivedEventArgs(string title , string body)
        {
            Title = title;
            Body = body;
        }
    }
}