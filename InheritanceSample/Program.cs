using System;

namespace InheritanceSample
{
    internal class Program
    {
        private static void Main()
        {
            var test = new DerivedSample();
            Console.WriteLine("As DerivedSample:");
            test.Fun();
            test.Fun2();

            Sample baseClass = test;

            Console.WriteLine("As Sample:");
            baseClass.Fun();
            baseClass.Fun2();

            Console.ReadLine();
        }
    }

    public class Sample
    {
        public int X;

        public virtual void Fun()
        {
            Console.WriteLine("Sample");
        }

        public void Fun2()
        {
            Console.WriteLine("Sample Fun2");
        }
    }

    public class DerivedSample : Sample
    {
        public override void Fun()
        {
            Console.WriteLine("DerivedSample");
        }

        public new void Fun2()
        {
            Console.WriteLine("DerivedSample Fun2");
        }
    }
}