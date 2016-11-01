using System;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Board.Board
{
    [ToString]
    [Equals]
    public sealed class CellInformation : ICellInformation
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public Cell.Status Status { get; set; }
        public int NeighboursAlive { get; set; }

        public int CompareTo(ICellInformation other)
        {
            // todo testing
            if ( RowIndex.CompareTo(other.RowIndex) == 0 &&
                 ColumnIndex.CompareTo(other.ColumnIndex) == 0 &&
                 Status.CompareTo(other.Status) == 0 &&
                 NeighboursAlive.CompareTo(other.NeighboursAlive) == 0 )
            {
                return 0;
            }

            double distanceThis = DistanceFromOrigin();
            double distanceOther = other.DistanceFromOrigin();

            if ( distanceThis < distanceOther )
            {
                return -1;
            }
            return 1;
        }

        public double DistanceFromOrigin()
        {
            return Math.Sqrt(RowIndex * RowIndex +
                             ColumnIndex * ColumnIndex);
        }
    }
}