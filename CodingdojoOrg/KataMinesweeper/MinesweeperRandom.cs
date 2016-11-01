using System;
using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ExcludeFromCodeCoverage]
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesweeperRandom : IRandom
    {
        private readonly Random m_Random = new Random();

        public int Next(int minimum,
                        int maximum)
        {
            return m_Random.Next(minimum,
                                 maximum);
        }
    }
}