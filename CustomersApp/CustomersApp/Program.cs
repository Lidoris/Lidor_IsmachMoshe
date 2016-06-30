using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> listOfCustomer = new List<Customer>(); 
            List<Customer> listAfterFilter;
            CustomerFilter customerFilterA_K = new CustomerFilter(FilterByLettersA_K);
            CustomerFilter customerFilterL_Z = new CustomerFilter(delegate(Customer customer)
            {
                return customer.Name[0] >= 'L' && customer.Name[0] <= 'Z';
            });
            CustomerFilter customerFilterID = new CustomerFilter(customer => customer.ID < 100);

            listOfCustomer.Add(new Customer(11, "Lidor", "Ben Gurion St."));
            listOfCustomer.Add(new Customer(134, "Hadar", "Hashalom Road"));
            listOfCustomer.Add(new Customer(23, "Sapir", "Bitzaron St."));
            listOfCustomer.Add(new Customer(99, "Idan", "Derech Degin St."));

            Console.WriteLine("The original array: \n");
            foreach (Customer customer in listOfCustomer)
            {
                Console.WriteLine(customer);
            }

            listAfterFilter = GetCustomers(listOfCustomer, customerFilterA_K);
            Console.WriteLine("after filter A-K: \n");
            foreach (Customer customer in listAfterFilter)
            {
                Console.WriteLine(customer);
            }

            listAfterFilter = GetCustomers(listOfCustomer, customerFilterL_Z);
            Console.WriteLine("after filter L-Z: \n");
            foreach (Customer customer in listAfterFilter)
            {
                Console.WriteLine(customer);
            }


            listAfterFilter = GetCustomers(listOfCustomer, customerFilterID);
            Console.WriteLine("after filter ID less then 100: \n");
            foreach (Customer customer in listAfterFilter)
            {
                Console.WriteLine(customer);
            }

        }

        public static List<Customer> GetCustomers (List<Customer> listBeforeFilter, CustomerFilter filter)
        {
            List<Customer> listAfterFilter = new List<Customer>();

            if (filter != null)
            {
                foreach (Customer customer in listBeforeFilter)
                {
                    if (filter(customer))
                    {
                        listAfterFilter.Add(customer);
                    }
                }
            }

            return listAfterFilter;
        }

        public static bool FilterByLettersA_K(Customer customer)
        {
            if (customer.Name[0]>='A' && customer.Name[0]<='K')
            {
                return true;
            }

            return false;
        }
    }
}
