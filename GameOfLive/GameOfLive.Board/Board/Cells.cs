using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLive.Interfaces.Board;

namespace GameOfLive.Board.Board
{
    public sealed class Cells : ICells
    {
        private readonly Dictionary <int, Cell.Status> m_Cells = new Dictionary <int, Cell.Status>();

        public Cell.Status GetStatus(int index)
        {
            Cell.Status status;

            if ( m_Cells.TryGetValue(index,
                                     out status) )
            {
                return status;
            }

            return Cell.Status.Dead;
        }

        public void SetStatus(int index,
                              Cell.Status status)
        {
            switch ( status )
            {
                case Cell.Status.Alive:
                    m_Cells [ index ] = status;
                    break;

                case Cell.Status.Dead:
                    m_Cells.Remove(index);
                    break;

                default:
                    string text = string.Format("Unknown Cell.Status '{0}'!",
                                                status);
                    throw new ArgumentException(text);
            }
        }

        public bool AreAllDead()
        {
            return m_Cells.Values.All(x => x != Cell.Status.Alive);
        }

        public IEnumerable <int> GetAllAlive()
        {
            return m_Cells.Keys.ToArray();
        }
    }
}