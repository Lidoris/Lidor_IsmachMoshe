﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class A
    {
        public string Hello (string str)
        {
            return string.Format("Hello {0}", str);
        }
    }
}
