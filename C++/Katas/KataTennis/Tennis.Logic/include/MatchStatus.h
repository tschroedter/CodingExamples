#pragma once

namespace Tennis
{
    namespace Logic
    {
        enum MatchStatus
        {
            MatchStatus_NotStarted,
            MatchStatus_InProgress,
            MatchStatus_PlayerOneWon,
            MatchStatus_PlayerTwoWon,
            MatchStatus_Max
        };
    };
};