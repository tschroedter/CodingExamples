#pragma once

namespace Tennis
{
    namespace Logic
    {
        enum GameStatus
        {
            NotStarted,
            InProgress,
            Deuce,
            AdvandtagePlayerOne,
            AdvandtagePlayerTwo,
            PlayerOneWon,
            PlayerTwoWon,
            GameStatus_Max
        };
    };
};
