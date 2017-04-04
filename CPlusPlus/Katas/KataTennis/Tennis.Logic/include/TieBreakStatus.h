#pragma once

namespace Tennis
{
    namespace Logic
    {
        enum TieBreakStatus
        {
            TieBreakStatus_NotStarted,  // todo check odd behaviour when removing TieBreakStatus_*
            TieBreakStatus_InProgress,
            TieBreakStatus_PlayerOneWon,
            TieBreakStatus_PlayerTwoWon,
            TieBreakStatus_GameStatus_Max
        };
    };
};
