// you can also use other imports, for example:
// using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

using System;

namespace FrogJump
{
    public class TestSolution
    {
        public int Solution(int x,
                            int y,
                            int distance)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            if (x >= y ||
                distance <= 0.0)
            {
                return 0;
            }

            double length = y - x;
            double jumps = length/distance;

            return (int) Math.Ceiling(jumps);
        }
    }
}