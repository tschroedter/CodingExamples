using System.Collections.Generic;
using System.Linq;
using GameOfLive.Interfaces;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Board
{
    public sealed class CellInformationToStringConverter : ICellInformationToStringConverter
    {
        public IEnumerable <string> Convert(IEnumerable <ICellInformation> cells)
        {
            ICellInformation[] array = cells.ToArray();

            int rowMinimum = GetRowMinimum(array);
            int rowMaximum = GetRowMaximum(array);
            int columnMinimum = GetColumnMinimum(array);
            int columnMaximum = GetColumnMaximum(array);

            int rowSize = rowMaximum - rowMinimum + 1; // todo only works for positive
            int columnSize = columnMaximum - columnMinimum + 1; // todo only works for positive

            // all dead
            var text = new Dictionary <int, string>();

            for ( var row = 0 ; row < rowSize ; row++ )
            {
                var buffer = new char[columnSize];

                for ( var i = 0 ; i < columnSize ; i++ )
                {
                    buffer [ i ] = ' ';
                }

                text.Add(row,
                         string.Join("",
                                     buffer));
            }

            // fill with alive
            foreach ( ICellInformation cell in array )
            {
                int key = cell.RowIndex - rowMinimum;

                char[] row = text [ key ].ToArray();

                row [ cell.ColumnIndex - columnMinimum ] = '*';

                text [ key ] = string.Join("",
                                           row);
            }

            return text.Values;
        }

        private int GetRowMinimum(IEnumerable <ICellInformation> cells)
        {
            int minimum = int.MaxValue;

            foreach ( ICellInformation cell in cells )
            {
                if ( cell.RowIndex < minimum )
                {
                    minimum = cell.RowIndex;
                }
            }

            return minimum;
        }

        private int GetRowMaximum(IEnumerable <ICellInformation> cells)
        {
            int maximum = int.MinValue;

            foreach ( ICellInformation cell in cells )
            {
                if ( cell.RowIndex > maximum )
                {
                    maximum = cell.RowIndex;
                }
            }

            return maximum;
        }

        private int GetColumnMinimum(IEnumerable <ICellInformation> cells)
        {
            int minimum = int.MaxValue;

            foreach ( ICellInformation cell in cells )
            {
                if ( cell.ColumnIndex < minimum )
                {
                    minimum = cell.ColumnIndex;
                }
            }

            return minimum;
        }

        private int GetColumnMaximum(IEnumerable <ICellInformation> cells)
        {
            int maximum = int.MinValue;

            foreach ( ICellInformation cell in cells )
            {
                if ( cell.ColumnIndex > maximum )
                {
                    maximum = cell.ColumnIndex;
                }
            }

            return maximum;
        }
    }
}