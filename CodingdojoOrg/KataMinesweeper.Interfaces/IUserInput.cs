using System;

namespace KataMinesweeper.Interfaces
{
    public interface IUserInput
    {
        Tuple <int, int> AskUserForRowAndCoumn(int maximumRow,
                                               int maximumColumn);
    }
}