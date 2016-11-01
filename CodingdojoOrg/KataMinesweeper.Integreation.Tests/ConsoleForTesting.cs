using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;

namespace KataMinesweeper.Integreation.Tests
{
    internal sealed class ConsoleForTesting : IConsole
    {
        private readonly IConsole m_Console;
        private readonly List <string> m_WrittenLines = new List <string>();
        private bool m_LastCallWasWrite;

        public ConsoleForTesting([NotNull] IConsole console)
        {
            m_Console = console;
        }

        private string[] m_ReadLines =
        {
        };

        [NotNull]
        public string[] ReadLines
        {
            get
            {
                return m_ReadLines;
            }
            set
            {
                m_ReadLines = value;
            }
        }

        public int ReadLineIndex { get; private set; }

        public void WriteLine(string text)
        {
            m_WrittenLines.Add(text);

            m_Console.WriteLine(text);
        }

        public string ReadLine()
        {
            // Don't ask console for input!
            if ( ReadLineIndex >= ReadLines.Length )
            {
                return ReadLines [ ReadLines.Length - 1 ];
            }

            string input = ReadLines [ ReadLineIndex ];

            ReadLineIndex++;

            return input;
        }

        public void Write(string format,
                          params object[] args)
        {
            DoExtraWriteProcessing(format,
                                   args);

            m_Console.Write(format,
                            args);
        }

        private void DoExtraWriteProcessing(string format,
                                              object[] args)
        {
            string text = format.Inject(args);

            m_WrittenLines.Add(text);

            m_LastCallWasWrite = true;
        }

        public void WriteLine(string format,
                              params object[] args)
        {
            DoExtraWriteLineProcessing(format,
                                       args);

            m_Console.WriteLine(format,
                                args);
        }

        private void DoExtraWriteLineProcessing(string format,
                                                  object[] args)
        {
            string text = format.Inject(args);

            if ( m_LastCallWasWrite )
            {
                string lastLine = m_WrittenLines.Last();

                m_WrittenLines.Remove(lastLine);

                text = lastLine + text;

                m_LastCallWasWrite = false;
            }

            m_WrittenLines.Add(text);
        }

        [NotNull]
        public string[] WrittenLines()
        {
            return m_WrittenLines.ToArray();
        }
    }
}