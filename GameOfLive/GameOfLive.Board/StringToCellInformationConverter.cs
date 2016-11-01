using System.Collections.Generic;
using GameOfLive.Board.Board;
using GameOfLive.Interfaces;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Board
{
    public sealed class StringToCellInformationConverter : IStringToCellInformationConverter
    {
        public IEnumerable <ICellInformation> Convert(string[] text)
        {
            var list = new List <ICellInformation>();

            for ( var row = 0 ; row < text.GetLength(0) ; row++ )
            {
                for ( var column = 0 ; column < text [ row ].Length ; column++ )
                {
                    Cell.Status status = text [ row ] [ column ] == ' '
                                             ? Cell.Status.Dead
                                             : Cell.Status.Alive;

                    if ( status == Cell.Status.Dead )
                    {
                        continue;
                    }

                    var info = new CellInformation
                               {
                                   RowIndex = row,
                                   ColumnIndex = column,
                                   Status = status,
                                   NeighboursAlive = 0
                               };

                    list.Add(info);
                }
            }

            return list;
        }
    }
}