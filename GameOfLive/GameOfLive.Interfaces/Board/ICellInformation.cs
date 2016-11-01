using System;

namespace GameOfLive.Interfaces.Board
{
    public interface ICellInformation : IComparable <ICellInformation>
    {
        int RowIndex { get; set; }
        int ColumnIndex { get; set; }
        Cell.Status Status { get; set; }
        int NeighboursAlive { get; set; } // todo testing
        double DistanceFromOrigin();
    }
}