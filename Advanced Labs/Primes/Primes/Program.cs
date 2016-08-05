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
                listOfPrimes = CalcPrimes(2, 10, 2);
                foreach (var number in listOfPrimes)
                {
                    Console.WriteLine(number);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static List<long> CalcPrimes(long firstNum, long secondNum , int degree)
        {
            List<long> ListOfPrimes = new List<long>();
            bool isPrime;
            long minNum, maxNum;

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
                        ListOfPrimes.Add(i);
                    }
                 });
            }

            return ListOfPrimes;
        }
    }
}
