#pragma once

<<<<<<< HEAD
#pragma once
#include <string>
=======
>>>>>>> Update from private repository
#include "MatchStatus.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
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
=======
        class MatchStatusToStringConverter
        {
        public:
            static std::string to_string ( const MatchStatus match_status )
            {
                using namespace Logic;

                std::string status = "";

                switch ( match_status )
                {
                    case MatchStatus_NotStarted :
                        return "NotStarted";
                    case MatchStatus_InProgress :
                        return "InProgress";
                    case MatchStatus_PlayerOneWon :
                        return "PlayerOneWon";
                    case MatchStatus_PlayerTwoWon :
                        return "PlayerTwoWon";
                    case MatchStatus_Max :
                        return "Max";
                    default :
                        return "Unknown";
>>>>>>> Update from private repository
                }
            }
        };
    };
<<<<<<< HEAD
};
=======
};
>>>>>>> Update from private repository
