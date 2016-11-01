using System;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class UserInput : IUserInput
    {
        internal const int InvalidRow = -1;
        internal const int InvalidColum = -1;
        private readonly IConsole m_Console;

        public UserInput([NotNull] IConsole console)
        {
            m_Console = console;
        }

        public Tuple <int, int> AskUserForRowAndCoumn(int maximumRow,
                                                      int maximumColumn)
        {
            int row = -1;
            int column = -1;

            while ( row < 0 ||
                    column < 0 )
            {
                m_Console.Write("Input Row, Column: ");

                string input = m_Console.ReadLine();

                if ( input != null )
                {
                    Tuple <int, int> rowAndColumn = ExtractRowAndColumn(input,
                                                                        maximumRow,
                                                                        maximumColumn);

                    row = rowAndColumn.Item1;
                    column = rowAndColumn.Item2;
                }
            }

            return new Tuple <int, int>(row,
                                        column);
        }

        internal Tuple <int, int> ExtractRowAndColumn([NotNull] string input,
                                                      int maximumRow,
                                                      int maximumColumn)
        {
            string[] rowAndColumn = input.Split(',');

            int row = InvalidRow;
            int column = InvalidColum;

            if ( rowAndColumn.Length == 2 )
            {
                row = ConvertToRow(row,
                                 rowAndColumn);

                column = ConvertToColumn(column,
                                         rowAndColumn);

                row = ValidateRow(maximumRow,
                                  row);

                column = ValidateColumn(maximumColumn,
                                        column);
            }

            return new Tuple <int, int>(row,
                                        column);
        }

        private int ConvertToColumn(int column,
                                    string[] rowAndColumn)
        {
            try
            {
                column = Convert.ToInt32(rowAndColumn [ 1 ]);
            }
            catch ( FormatException exception )
            {
                m_Console.WriteLine("Error: {0}",
                                    exception.Message);
            }
            return column;
        }

        private int ConvertToRow(int row,
                               string[] rowAndColumn)
        {
            try
            {
                row = Convert.ToInt32(rowAndColumn [ 0 ]);
            }
            catch ( FormatException exception )
            {
                m_Console.WriteLine("Error: {0}",
                                    exception.Message);
            }
            return row;
        }

        private int ValidateColumn(int maximumColumn,
                                   int column)
        {
            if ( column < 0 ||
                 column > maximumColumn )
            {
                m_Console.WriteLine("Error: Column must be between 0 and {0}!",
                                    maximumColumn);

                column = -1;
            }
            return column;
        }

        private int ValidateRow(int maximumRow,
                                int row)
        {
            if ( row < 0 ||
                 row > maximumRow )
            {
                m_Console.WriteLine("Error: Row must be between 0 and {0}!",
                                    maximumRow);

                row = -1;
            }
            return row;
        }
    }
}