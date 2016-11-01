using System.Collections.Generic;

namespace GameOfLive.Interfaces.Board
{
    public interface ICells
    {
        Cell.Status GetStatus(int index);

        void SetStatus(int index,
                       Cell.Status status);

        bool AreAllDead();
        IEnumerable <int> GetAllAlive();
    }
}