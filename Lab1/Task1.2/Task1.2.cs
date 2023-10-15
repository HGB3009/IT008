using System;

namespace Task1._2
{
    public class Fraction : IComparable<Fraction>
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Numerator;
            int newDenominator = a.Denominator * b.Denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            int newNumerator = a.Numerator * b.Denominator;
            int newDenominator = a.Denominator * b.Numerator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !a.Equals(b);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return ((IComparable<Fraction>)a).CompareTo(b) < 0;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return ((IComparable<Fraction>)a).CompareTo(b) > 0;
        }

#pragma warning disable CS8769
        int IComparable<Fraction>.CompareTo(Fraction other)
#pragma warning restore CS8769
        {
            int crossProduct1 = Numerator * other.Denominator;
            int crossProduct2 = other.Numerator * Denominator;
            return crossProduct1.CompareTo(crossProduct2);
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number, 1);
        }

        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.Numerator / fraction.Denominator;
        }

        private void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

#pragma warning disable CS8765
        public override bool Equals(object obj)
#pragma warning restore CS8765
        {
            if (obj is Fraction other)
            {
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }
            return false;
        }

        class Program
        {
            static void Main()
            {
                Console.WriteLine("Demo fraction1: 1/2");
                Fraction fraction1 = new Fraction(1, 2);
                Console.WriteLine("Demo fraction1: 3/4");
                Fraction fraction2 = new Fraction(3, 4);

                Fraction sum = fraction1 + fraction2;
                Fraction difference = fraction1 - fraction2;
                Fraction product = fraction1 * fraction2;
                Fraction quotient = fraction1 / fraction2;

                Console.WriteLine("Sum: " + sum);
                Console.WriteLine("Difference: " + difference);
                Console.WriteLine("Product: " + product);
                Console.WriteLine("Quotient: " + quotient);

                Console.WriteLine("Is fraction1 equal to fraction2? " + (fraction1 == fraction2));
                Console.WriteLine("Is fraction1 not equal to fraction2? " + (fraction1 != fraction2));
                Console.WriteLine("Is fraction1 less than fraction2? " + (fraction1 < fraction2));
                Console.WriteLine("Is fraction1 greater than fraction2? " + (fraction1 > fraction2));

                Fraction fraction3 = 3;
                double decimalValue = (double)fraction3;

                Console.WriteLine("Fraction from int: " + fraction3);
                Console.WriteLine("Fraction as double: " + decimalValue);

                Fraction[] fractions = { new Fraction(1, 3), new Fraction(1, 2), new Fraction(2, 3) };
                Array.Sort(fractions);
                Console.WriteLine("Sorted Fractions:");
                foreach (var fraction in fractions)
                {
                    Console.WriteLine(fraction);
                }
            }
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}