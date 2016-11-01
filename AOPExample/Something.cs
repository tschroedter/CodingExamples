using System;

namespace AOPExample
{
    class Something : ISomething
    {
        public int Augment(int input)
        {
            return input + 1;
        }

        public void DoSomething(string input)
        {
            Console.WriteLine("I'm doing something: " + input);
        }

        public int Property
        {
            get;
            set;
        }
    }
}