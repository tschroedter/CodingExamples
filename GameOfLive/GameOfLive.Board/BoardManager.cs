using System.Collections.Generic;
using System.Linq;
using GameOfLive.Interfaces;
using GameOfLive.Interfaces.Board;
using GameOfLive.Interfaces.Rules;
using JetBrains.Annotations;

namespace GameOfLive.Board // todo change name of assembly
{
    public class BoardManager : IBoardManager
    {
        private readonly IBoard m_Board;
        private readonly IEngine m_Engine;

        public BoardManager([NotNull] IBoard board,
                            [NotNull] IEngine engine)
        {
            m_Board = board;
            m_Engine = engine;
        }

        public void SetDeadCell(int rowIndex,
                                int columnIndex)
        {
            m_Board.SetStatus(rowIndex,
                              columnIndex,
                              Cell.Status.Dead);
        }

        public void SetAliveCell(int rowIndex,
                                 int columnIndex)
        {
            m_Board.SetStatus(rowIndex,
                              columnIndex,
                              Cell.Status.Alive);
        }

        public void NextGeneration()
        {
            // todo
            IEnumerable <ICellInformation> cells = m_Board.LivingCells().ToArray();

            var list = new List <ICellInformation>();
            list.AddRange(cells);

            foreach ( ICellInformation cell in cells )
            {
                IEnumerable <ICellInformation> neighbours = m_Board.Neighbours(cell);

                foreach ( ICellInformation neighbour in neighbours )
                {
                    bool exits = list.Any(x => x.RowIndex == neighbour.RowIndex &&
                                               x.ColumnIndex == neighbour.ColumnIndex);

                    if ( !exits )
                    {
                        list.Add(neighbour);
                    }
                }
            }

            m_Engine.ApplyRules(list);

            m_Board.Update(list);
        }

        public void Update(IEnumerable <ICellInformation> cells)
        {
            m_Board.Update(cells);
        }

        public IEnumerable <ICellInformation> LivingCells()
        {
            return m_Board.LivingCells();
        }
    }
}