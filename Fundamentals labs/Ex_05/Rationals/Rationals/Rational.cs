using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public struct Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public double Value
        {
            get
            {
                if(Denominator != 0)
                {
                    return Numerator / (double)Denominator;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Rational(int numerator, int denominator)
        {
            if(denominator != 0)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            else
            {
                throw new ArgumentException("The denominator can not be zero");
            }
        }

        public Rational(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public static Rational operator+(Rational numA, Rational numB)
        {
            Rational result;

            if (numA.Denominator == numB.Denominator)
            {
                result = new Rational(numA.Numerator + numB.Numerator, numA.Denominator);
            }
            else
            {
                result = new Rational((numA.Numerator * numB.Denominator) + (numB.Numerator * numA.Denominator), numA.Denominator * numB.Denominator);
            }
           
            return result;
        }

        public static Rational operator-(Rational numA, Rational numB)
        {
            Rational result;

            if (numA.Denominator == numB.Denominator)
            {
                result = new Rational(numA.Numerator - numB.Numerator, numA.Denominator);
            }
            else if (numA.Value != numB.Value)
            {
                result = new Rational((numA.Numerator * numB.Denominator) - (numB.Numerator * numA.Denominator), numA.Denominator * numB.Denominator);
            }
            else
            {
                result = new Rational(0, 0);
            }

            return result;
        }

        public static Rational operator*(Rational numA, Rational numB)
        {
            Rational result;

            result = new Rational(numA.Numerator*numB.Numerator, numA.Denominator*numB.Denominator);
           
            return result;
        }

        public static Rational operator /(Rational numA, Rational numB) 
        {
            Rational result;

            result = new Rational(numA.Numerator * numB.Denominator, numA.Denominator * numB.Numerator);

            return result;
        }


        public void Reduce ()
        {
            int min = Math.Min(Numerator, Denominator);
            if (this.Numerator % this.Denominator == 0 || this.Denominator % this.Numerator == 0)
            {
                this.Numerator = this.Numerator / min;
                this.Denominator = this.Denominator / min;
            }
        }

        public override bool Equals(object obj)
        {
            bool result;

            if ((this.Numerator == ((Rational)obj).Numerator) && (this.Denominator == ((Rational)obj).Denominator))
            { 
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder rationalStr = new StringBuilder();

            rationalStr.AppendFormat("[ {0}/{1} ] = {2:0.###}", Numerator, Denominator, Value);
            return rationalStr.ToString();
        }
    }
}
