#pragma once

namespace Tennis
{
    namespace Logic
    {
        enum SetStatus
        {
            SetStatus_NotStarted,
            SetStatus_InProgress,
            SetStatus_InTieBreak,
            SetStatus_PlayerOneWon,
            SetStatus_PlayerTwoWon,
            SetStatus_Max
        };
    };
};