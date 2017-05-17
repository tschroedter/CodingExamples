#pragma once
#include "ISetStatusCalculator.h"
#include "ITieBreak.h"
#include "IGamesCounter.h"
#include "ICountPlayerGames.h"

namespace Tennis
{
    namespace Logic
    {
        class SetStatusCalculator
                : public ISetStatusCalculator
        {
        private:
            static const int8_t MAX_GAME_SCORE = 6;
            static const int8_t WON_TIE_BREAK_SCORE = MAX_GAME_SCORE + 1;

            ICountPlayerGames_Ptr m_counter;

            static bool SetStatusCalculator::has_score_one_won_set (
                const int8_t score_one,
                const int8_t score_two );
            static bool has_player_won_set (
                const Player player,
                const int8_t games_for_player_one,
                const int8_t games_for_player_two );
            static bool is_in_tie_break (
                const int8_t games_for_player_one,
                const int8_t games_for_player_two );
            static bool is_in_progress (
                const int8_t games_for_player_one,
                const int8_t games_for_player_two );

        public:
            SetStatusCalculator (
                ICountPlayerGames_Ptr counter )
                : m_counter ( counter )
            {
            }

            ~SetStatusCalculator ()
            {
            }

            const SetStatus get_status ( const IGames_Ptr games,
                                         const ITieBreak_Ptr tie_break ) const override;
        };
    };
};
