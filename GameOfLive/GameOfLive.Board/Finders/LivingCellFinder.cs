using System.Collections.Generic;
using GameOfLive.Board.Board;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Finders;
using JetBrains.Annotations;

namespace GameOfLive.Board.Finders
{
    public sealed class LivingCellFinder : ILivingCellFinder
    {
        private readonly INeighboursFinder m_Finder;

        public LivingCellFinder([NotNull] INeighboursFinder finder)
        {
            m_Finder = finder;
        }

        public IEnumerable <ICellInformation> Find(Dictionary <int, ICells> rows)
        {
            var list = new List <CellInformation>();

            foreach ( KeyValuePair <int, ICells> row in rows )
            {
                IEnumerable <int> aliveInRow = row.Value.GetAllAlive();

                foreach ( int index in aliveInRow )
                {
                    var info = new CellInformation
                               {
                                   RowIndex = row.Key,
                                   ColumnIndex = index,
                                   Status = Cell.Status.Alive,
                                   NeighboursAlive = m_Finder.NumberOfAliveNeighbours(rows,
                                                                                      row.Key,
                                                                                      index)
                               };

                    list.Add(info);
                }
            }

            return list;
        }

        public IEnumerable <ICellInformation> Neighbours(Dictionary <int, ICells> rows,
                                                         int rowIndex,
                                                         int columnIndex)
        {
            return m_Finder.Neighbours(rows,
                                       rowIndex,
                                       columnIndex);
        }
    }
}