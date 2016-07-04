using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rationals;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Rational rationalA = new Rational(4, 8);
                Rational rationalB = new Rational(1, 3);

                Console.WriteLine(" rationalA Value : {0}", rationalA);
                Console.WriteLine(" rationalB Value : {0}", rationalB);

                Console.WriteLine(" The sum of rationalA and rationalB is : {0}", rationalA + rationalB);
                Console.WriteLine(" The result of multiplying rationalA and rationalB is : {0}", rationalA * rationalB);
                Console.WriteLine(" The result after subtract rationalB from rationalA is : {0}", rationalA - rationalB);
                Console.WriteLine(" The result after Divide rationalA by rationalB is : {0}", rationalA / rationalB);

                rationalA.Reduce();
                Console.WriteLine(" rationalA Value after reduce : {0}", rationalA);
                Console.WriteLine(" Is rationalA and rationalB are Equals: {0}", rationalA.Equals(rationalB));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
