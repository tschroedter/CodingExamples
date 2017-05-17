#pragma once

namespace Tennis
{
    namespace Logic
    {
        enum TieBreakStatus
        {
            TieBreakStatus_NotStarted,
            TieBreakStatus_InProgress,
            TieBreakStatus_PlayerOneWon,
            TieBreakStatus_PlayerTwoWon,
            TieBreakStatus_GameStatus_Max
        };
    };
};
