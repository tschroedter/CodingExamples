using System.Collections.Generic;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class StringToMineFieldConverter : IStringToMineFieldConverter
    {
        private const char Mine = '*';

        public IMineField ToMineField(string text)
        {
            string[] lines = text.Split('\n');

            var noWhiteSpaces = new List <string>();

            foreach ( string line in lines )
            {
                string noWhiteSpace = line.TrimEnd('\r',
                                                   '\n');

                noWhiteSpaces.Add(noWhiteSpace);
            }

            IMineField mineField = LinesToMineField(noWhiteSpaces.ToArray());

            return mineField;
        }

        private static MineField LinesToMineField([NotNull] string[] lines)
        {
            int numberOfRows = lines.Length;
            int numberOfColumns = lines [ 0 ].Length;

            var mineField = new MineField(numberOfRows,
                                          numberOfColumns);

            for ( var row = 0 ; row < numberOfRows ; row++ )
            {
                char[] chars = lines [ row ].ToCharArray();

                for ( var column = 0 ; column < numberOfColumns ; column++ )
                {
                    if ( chars [ column ] == Mine )
                    {
                        mineField.PutMineAt(row,
                                            column);
                    }
                }
            }
            return mineField;
        }
    }
}