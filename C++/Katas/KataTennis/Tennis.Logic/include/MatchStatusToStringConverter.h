#pragma once

#pragma once
#include <string>
#include "MatchStatus.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchStatusToStringConverter  // todo testing
        {
        public:
            static std::string to_string(const MatchStatus match_status)
            {
                using namespace Tennis::Logic;

                std::string status = "";

                switch (match_status)
                {
                case MatchStatus_NotStarted:
                    return "NotStarted";
                case MatchStatus_InProgress:
                    return "InProgress";
                case MatchStatus_PlayerOneWon:
                    return "PlayerOneWon";
                case MatchStatus_PlayerTwoWon:
                    return "PlayerTwoWon";
                case MatchStatus_Max:
                    return "Max";
                default:
                    return "Unknown";
                }
            }
        };
    };
};