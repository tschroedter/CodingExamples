using System.Collections.Generic;
using GameOfLive.Board.Board;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Finders;
using JetBrains.Annotations;

namespace GameOfLive.Board.Finders
{
    // todo use Position class X,Y
    public sealed class NeighboursFinder : INeighboursFinder
    {
        public int NumberOfAliveNeighbours(Dictionary <int, ICells> rows,
                                           int rowIndex,
                                           int columnIndex)
        {
            var aliveNeighbours = 0;

            if ( Cell.Status.Alive == North(rows,
                                            rowIndex,
                                            columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == South(rows,
                                            rowIndex,
                                            columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == East(rows,
                                           rowIndex,
                                           columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == West(rows,
                                           rowIndex,
                                           columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == NorthEast(rows,
                                                rowIndex,
                                                columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == SouthEast(rows,
                                                rowIndex,
                                                columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == NorthWest(rows,
                                                rowIndex,
                                                columnIndex) )
            {
                aliveNeighbours++;
            }

            if ( Cell.Status.Alive == SouthWest(rows,
                                                rowIndex,
                                                columnIndex) )
            {
                aliveNeighbours++;
            }

            return aliveNeighbours;
        }

        //todo testing, should be in separate class
        public IEnumerable <ICellInformation> Neighbours(Dictionary <int, ICells> rows,
                                                         int rowIndex,
                                                         int columnIndex)
        {
            ICellInformation north = NeighbourNorth(rows,
                                                    rowIndex,
                                                    columnIndex);
            ICellInformation south = NeighbourSouth(rows,
                                                    rowIndex,
                                                    columnIndex);
            ICellInformation east = NeighbourEast(rows,
                                                  rowIndex,
                                                  columnIndex);
            ICellInformation west = NeighbourWest(rows,
                                                  rowIndex,
                                                  columnIndex);

            ICellInformation northEast = NeighbourNorthEast(rows,
                                                            rowIndex,
                                                            columnIndex);
            ICellInformation southEast = NeighbourSouthEast(rows,
                                                            rowIndex,
                                                            columnIndex);
            ICellInformation northWest = NeighbourNorthWest(rows,
                                                            rowIndex,
                                                            columnIndex);
            ICellInformation southWest = NeighbourSouthWest(rows,
                                                            rowIndex,
                                                            columnIndex);

            var neighbours = new[]
                             {
                                 north,
                                 south,
                                 east,
                                 west,
                                 northEast,
                                 southEast,
                                 northWest,
                                 southWest
                             };

            return neighbours;
        }

        private Cell.Status SouthWest([NotNull] Dictionary <int, ICells> rows,
                                      int rowIndex,
                                      int columnIndex)
        {
            Cell.Status southWest = GetStatus(rows,
                                              rowIndex + 1,
                                              columnIndex - 1);
            return southWest;
        }

        private Cell.Status NorthWest([NotNull] Dictionary <int, ICells> rows,
                                      int rowIndex,
                                      int columnIndex)
        {
            Cell.Status northWest = GetStatus(rows,
                                              rowIndex - 1,
                                              columnIndex - 1);
            return northWest;
        }

        private Cell.Status SouthEast([NotNull] Dictionary <int, ICells> rows,
                                      int rowIndex,
                                      int columnIndex)
        {
            Cell.Status southEast = GetStatus(rows,
                                              rowIndex + 1,
                                              columnIndex + 1);
            return southEast;
        }

        private Cell.Status NorthEast([NotNull] Dictionary <int, ICells> rows,
                                      int rowIndex,
                                      int columnIndex)
        {
            Cell.Status northEast = GetStatus(rows,
                                              rowIndex - 1,
                                              columnIndex + 1);
            return northEast;
        }

        private Cell.Status West([NotNull] Dictionary <int, ICells> rows,
                                 int rowIndex,
                                 int columnIndex)
        {
            Cell.Status west = GetStatus(rows,
                                         rowIndex,
                                         columnIndex + 1);
            return west;
        }

        private Cell.Status East([NotNull] Dictionary <int, ICells> rows,
                                 int rowIndex,
                                 int columnIndex)
        {
            Cell.Status east = GetStatus(rows,
                                         rowIndex,
                                         columnIndex - 1);
            return east;
        }

        private Cell.Status South([NotNull] Dictionary <int, ICells> rows,
                                  int rowIndex,
                                  int columnIndex)
        {
            Cell.Status south = GetStatus(rows,
                                          rowIndex + 1,
                                          columnIndex);
            return south;
        }

        private Cell.Status North([NotNull] Dictionary <int, ICells> rows,
                                  int rowIndex,
                                  int columnIndex)
        {
            Cell.Status north = GetStatus(rows,
                                          rowIndex - 1,
                                          columnIndex);
            return north;
        }

        private Cell.Status GetStatus([NotNull] Dictionary <int, ICells> rows,
                                      int rowIndex,
                                      int columnIndex)
        {
            ICells cells;

            if ( rows.TryGetValue(rowIndex,
                                  out cells) )
            {
                return cells.GetStatus(columnIndex);
            }

            return Cell.Status.Dead;
        }

        private ICellInformation NeighbourSouthWest([NotNull] Dictionary <int, ICells> rows,
                                                    int rowIndex,
                                                    int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex + 1,
                                         columnIndex - 1);
        }

        private ICellInformation NeighbourNorthWest([NotNull] Dictionary <int, ICells> rows,
                                                    int rowIndex,
                                                    int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex - 1,
                                         columnIndex - 1);
        }

        private ICellInformation NeighbourSouthEast([NotNull] Dictionary <int, ICells> rows,
                                                    int rowIndex,
                                                    int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex + 1,
                                         columnIndex + 1);
        }

        private ICellInformation NeighbourNorthEast([NotNull] Dictionary <int, ICells> rows,
                                                    int rowIndex,
                                                    int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex - 1,
                                         columnIndex + 1);
        }

        private ICellInformation NeighbourWest([NotNull] Dictionary <int, ICells> rows,
                                               int rowIndex,
                                               int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex,
                                         columnIndex + 1);
        }

        private ICellInformation NeighbourEast([NotNull] Dictionary <int, ICells> rows,
                                               int rowIndex,
                                               int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex,
                                         columnIndex - 1);
        }

        private ICellInformation NeighbourSouth([NotNull] Dictionary <int, ICells> rows,
                                                int rowIndex,
                                                int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex + 1,
                                         columnIndex);
        }

        private ICellInformation NeighbourNorth([NotNull] Dictionary <int, ICells> rows,
                                                int rowIndex,
                                                int columnIndex)
        {
            return CreateCellInformation(rows,
                                         rowIndex - 1,
                                         columnIndex);
        }

        private ICellInformation CreateCellInformation(Dictionary <int, ICells> rows,
                                                       int rowIndex,
                                                       int columnIndex)
        {
            Cell.Status status = GetStatus(rows,
                                           rowIndex,
                                           columnIndex);

            int numberOfAliveNeighbours = NumberOfAliveNeighbours(rows,
                                                                  rowIndex,
                                                                  columnIndex);

            var cell = new CellInformation
                       {
                           RowIndex = rowIndex,
                           ColumnIndex = columnIndex,
                           Status = status,
                           NeighboursAlive = numberOfAliveNeighbours
                       };

            return cell;
        }
    }
}