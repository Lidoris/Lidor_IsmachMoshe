using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            int result;

            if(x != null)
            {
                if (y != null)
                {
                    if (x.ID == y.ID)
                    {
                        result = 0;
                    }
                    else if (x.ID > y.ID)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    result = 1;
                }
            }
            else if (y != null)
            {
                result = -1;
            }
            else
            {
                result = 0; // both objects are null
            }
            
            return result;
            
        }
    }
}
