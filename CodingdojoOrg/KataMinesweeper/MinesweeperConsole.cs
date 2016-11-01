using System;
using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ExcludeFromCodeCoverage]
    [ProjectComponent(Lifestyle.Transient)]
    public class MinesweeperConsole : IConsole
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string format,
                          params object[] args)
        {
            Console.Write(format,
                          args);
        }

        public void WriteLine(string format,
                              params object[] args)
        {
            Console.WriteLine(format,
                              args);
        }
    }
}