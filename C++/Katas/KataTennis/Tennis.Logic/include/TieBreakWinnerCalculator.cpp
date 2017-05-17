#include "ITieBreak.h"
#include "Player.h"
#include "TieBreakWinnerCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        bool TieBreakWinnerCalculator::was_tie_break_won_by_player(
            const ITieBreak* tie_break,
            Player player) const
        {
            if (tie_break)
            {
                TieBreakStatus tie_break_status = tie_break->get_status();

                switch (tie_break_status)
                {
                case TieBreakStatus_PlayerOneWon:
                    if (player == One)
                    {
                        return true;
                    }
                    break;
                case TieBreakStatus_PlayerTwoWon:
                    if (player == Two)
                    {
                        return true;
                    }
                    break;
                case TieBreakStatus_InProgress:
                case TieBreakStatus_NotStarted:
                case TieBreakStatus_GameStatus_Max:
                    return false;
                default:
                    return false;
                }
            }

            return false;
        }
    };
};