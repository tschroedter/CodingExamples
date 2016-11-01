using System;
using System.Diagnostics.CodeAnalysis;
using WiseTechGlobal.ChequeWriter;
using WiseTechGlobal.RomanCalculator;
using WiseTechGlobal.RomanNumerals;

namespace WiseTechGlobal.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            try
            {
                TestOne();
                TestTwo();
                TestThree();
            }
            catch ( Exception ex )
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadLine();
        }

        private static void TestOne()
        {
            System.Console.WriteLine("Test1: ChequeWriter");
            System.Console.Write("Amount (xxxx.yy): ");

            string amount = System.Console.ReadLine();

            if ( amount != null )
            {
                var converter = new DollarsCentsConverter();
                string text = converter.Convert(amount);

                System.Console.WriteLine(text);
            }
        }

        private static void TestTwo()
        {
            System.Console.WriteLine("Test2: Roman Numerals");
            System.Console.Write("Number: ");

            string value = System.Console.ReadLine();

            if ( value != null )
            {
                var converter = new RomanNumeralConverter();
                string text = converter.Convert(value);

                System.Console.WriteLine(text);
            }
        }

        private static void TestThree()
        {
            System.Console.WriteLine("Test3: Adding Roman Numerals");

            System.Console.Write("1. Number: ");
            string valueOne = System.Console.ReadLine();

            System.Console.Write("2. Number: ");
            string valueTwo = System.Console.ReadLine();

            if ( valueOne != null &&
                 valueTwo != null )
            {
                var calculator = new Calculator();

                string result = calculator.Add(valueOne,
                                               valueTwo);

                System.Console.WriteLine(result);
            }
        }
    }
}