using System;
using System.Collections.Generic;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Finders;
using JetBrains.Annotations;

namespace GameOfLive.Board.Board
{
    public sealed class UnlimitedBoard : IBoard
    {
        private readonly ILivingCellFinder m_LivingCellFinder;
        private readonly Dictionary <int, ICells> m_Rows = new Dictionary <int, ICells>();

        public UnlimitedBoard([NotNull] ILivingCellFinder livingCellFinder)
        {
            m_LivingCellFinder = livingCellFinder;
        }

        public Cell.Status GetStatus(int rowIndex,
                                     int columnIndex)
        {
            ICells cells;

            if ( m_Rows.TryGetValue(rowIndex,
                                    out cells) )
            {
                return cells.GetStatus(columnIndex);
            }

            return Cell.Status.Dead;
        }

        public void SetStatus(int rowIndex,
                              int columnIndex,
                              Cell.Status status)
        {
            switch ( status )
            {
                case Cell.Status.Alive:
                    SetCellToAlive(rowIndex,
                                   columnIndex);
                    break;

                case Cell.Status.Dead:
                    SetCellToDead(rowIndex,
                                  columnIndex);
                    break;

                default:
                    string text = string.Format("Unknown Cell.Status '{0}'!",
                                                status);
                    throw new ArgumentException(text);
            }
        }

        public IEnumerable <ICellInformation> LivingCells()
        {
            IEnumerable <ICellInformation> cellInformations = m_LivingCellFinder.Find(m_Rows);

            return cellInformations;
        }

        public void Update(IEnumerable <ICellInformation> cells)
        {
            // todo testing
            foreach ( ICellInformation cell in cells )
            {
                SetStatus(cell.RowIndex,
                          cell.ColumnIndex,
                          cell.Status);
            }
        }

        public IEnumerable <ICellInformation> Neighbours(ICellInformation cell)
        {
            return m_LivingCellFinder.Neighbours(m_Rows,
                                                 cell.RowIndex,
                                                 cell.ColumnIndex);
        }

        private void SetCellToDead(int rowIndex,
                                   int columnIndex)
        {
            ICells cells;

            if ( !m_Rows.TryGetValue(rowIndex,
                                     out cells) )
            {
                return;
            }

            cells.SetStatus(columnIndex,
                            Cell.Status.Dead);

            if ( cells.AreAllDead() )
            {
                m_Rows.Remove(rowIndex);
            }
        }

        private void SetCellToAlive(int rowIndex,
                                    int columnIndex)
        {
            ICells cells;

            if ( !m_Rows.TryGetValue(rowIndex,
                                     out cells) )
            {
                cells = new Cells();

                m_Rows.Add(rowIndex,
                           cells);
            }

            cells.SetStatus(columnIndex,
                            Cell.Status.Alive);
        }
    }
}