#pragma once
#include "ISetStatusCalculator.h"
#include "ITieBreak.h"
#include "IGames.h"
#include "IGamesCounter.h"

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

            IGames* m_games;
            ITieBreak* m_tie_break;
            std::unique_ptr<IGamesCounter> m_counter;

            static bool SetStatusCalculator::has_score_one_won_set(
                int8_t score_one,
                int8_t score_two);
            static bool has_player_won_set(
                Player player,
                int8_t games_for_player_one, 
                int8_t games_for_player_two);
            static bool is_in_tie_break(
                int8_t games_for_player_one, 
                int8_t games_for_player_two);
            static bool is_in_progress(
                int8_t games_for_player_one, 
                int8_t games_for_player_two);

        public:
            SetStatusCalculator (
                std::unique_ptr<IGamesCounter> counter,
                IGames* games,
                ITieBreak* tie_break )
                : m_games ( games )
                , m_tie_break ( tie_break )
                , m_counter ( std::move ( counter ) )
            {
            }

            virtual ~SetStatusCalculator ()
            {
            }

            const SetStatus get_status () const override;
        };
    };
};
