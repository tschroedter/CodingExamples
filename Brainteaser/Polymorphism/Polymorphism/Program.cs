using System;

namespace Polymorphism
{
    class Program
    {
        static void Main()
        {
            Animal animalCat = new Cat();
            Cat cat = new Cat();

            animalCat.Jump();
            cat.Jump();

            Console.ReadLine();
        }
    }
}
