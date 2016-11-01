using System;

namespace FrogJump
{
    // FROG JUMP
    public class FrogJump
    {
        public int Solution(int X, int Y, int D)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            double jumps = ((double)(Y - X)) / (double)D;

            int round = (int)Math.Ceiling(jumps);

            return round;
        }
    }
}
