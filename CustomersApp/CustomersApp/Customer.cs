using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);

    public class Customer : IComparable<Customer> , IEquatable<Customer>
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Customer(int id , string name, string address )
        {
            ID = id;
            Name = name;
            Address = address;
        }

        public int CompareTo(Customer other) // case insensitive way implement
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return string.Compare(Name, other.Name, true);
            }
        }

        public bool Equals(Customer other)
        {
            bool result;
            
            if (Name.Equals(other.Name) && ID.Equals(other.ID))
            {
                result = true;
            }
            else
            {
                result = false;
            }
           
            return result;
        }

        public override bool Equals(object obj)
        {
            bool result;

            if ((obj != null) && (obj is Customer))
            {
                result = Equals(obj as Customer);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[ ID:{0} ,Name:{1} ,Address:{2} ] {3}", ID, Name, Address,Environment.NewLine);
        }

       
    }
}
