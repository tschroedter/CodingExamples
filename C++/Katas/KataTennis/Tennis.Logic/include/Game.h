#pragma once

#include "GameScore.h"
#include "GameStatus.h"
#include "Player.h"
#include "IGame.h"
#include "ILogger.h"
#include "AwardPoints.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class Game
                : public IGame
        {
        private:
            IAwardPoints_Ptr m_award_points;
            IGameScore_Ptr m_score_player_one;
            IGameScore_Ptr m_score_player_two;
            GameStatus m_game_status = NotStarted;

            static bool isDeuce (
                Scores player_one,
                Scores player_two );

            void awardPoint ( const Player player ) const;

            void updateStatus ();

        public:
            Game (
                IAwardPoints_Ptr award_points,
                IGameScore_Ptr game_score_one,
                IGameScore_Ptr game_score_two )
                : m_award_points ( award_points )
                , m_score_player_one ( game_score_one )
                , m_score_player_two ( game_score_two )
            {
            }

            ~Game ()
            {
            }

            void won_point ( const Player player ) override;
            GameStatus get_status () const override;
            Scores get_score_for_player ( const Player player ) const override;
            std::string get_score_for_player_as_string ( const Player player ) const override;
        };
    };
};
