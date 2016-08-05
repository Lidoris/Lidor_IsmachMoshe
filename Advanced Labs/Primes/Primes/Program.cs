using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> listOfPrimes = new List<long>();
            try
            {
                // Lab 1: Using the Parallel Class
                //listOfPrimes = CalcPrimes(2, 30 , 4);
                //foreach (var number in listOfPrimes)
                //{
                //    Console.WriteLine(number);
                //}
                
                // Lab 2: Cancellation
                listOfPrimes = CalcPrimes(2, 30000000);
                Console.WriteLine("numbers returned before being cancelled {0}", listOfPrimes.Count);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Lab 2: Cancellation
        private static List<long> CalcPrimes(long firstNum, long secondNum)
        {
            List<long> ListOfPrimes = new List<long>();
            bool isPrime;
            long minNum, maxNum; 
            Random rand = new Random();
            object lockObj = new object();

            minNum = Math.Min(firstNum, secondNum);
            minNum = minNum < 1 ? 2 : minNum;
            maxNum = Math.Max(firstNum, secondNum);

            if (minNum < maxNum)
            {
                Parallel.For(minNum, maxNum, (i , x ) =>
                {
                    if (rand.Next(10000000) == 0)
                    {
                        x.Stop();
                    }

                    isPrime = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false; 
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        lock (lockObj)
                        { 
                            ListOfPrimes.Add(i);
                        }
                        
                    }
                });
            }

            return ListOfPrimes;
        }

       
        //Lab 1: Using the Parallel Class
        private static List<long> CalcPrimes(long firstNum, long secondNum , int degree)
        {
            List<long> ListOfPrimes = new List<long>();
            bool isPrime;
            long minNum, maxNum;
            object lockObj = new object();

            minNum = Math.Min(firstNum, secondNum);
            minNum = minNum < 1 ? 2 : minNum;
            maxNum = Math.Max(firstNum, secondNum);

            if (minNum < maxNum)
            {
                Parallel.For(minNum, maxNum, new ParallelOptions() { MaxDegreeOfParallelism = degree }, i =>
                 {
                    isPrime = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                         lock (lockObj)
                         {
                             ListOfPrimes.Add(i);
                         }
                     }
                 });
            }

            return ListOfPrimes;
        }
    }
}
