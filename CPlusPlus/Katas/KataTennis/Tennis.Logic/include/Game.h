#pragma once

#include "GameScore.h"
#include "GameStatus.h"
#include "Player.h"
#include "IGame.h"
#include "AwardPoints.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class Game
                : public IGame // todo dependency injection
        {
        private:
            std::unique_ptr<ILogger> m_logger;
            std::unique_ptr<IAwardPoints> m_award_points;
            std::unique_ptr<IGameScore> m_score_player_one;
            std::unique_ptr<IGameScore> m_score_player_two;
            GameStatus m_game_status = NotStarted;

            static bool isDeuce (
                Scores player_one,
                Scores player_two );

            void awardPoint ( const Player player ) const;

            void updateStatus ();

        public:
            Game (
                std::unique_ptr<ILogger> logger,
                std::unique_ptr<IAwardPoints> award_points,
                std::unique_ptr<IGameScore> game_score_one,
                std::unique_ptr<IGameScore> game_score_two )
                : m_logger ( std::move ( logger ) )
                , m_award_points ( std::move ( award_points ) )
                , m_score_player_one ( std::move ( game_score_one ) )
                , m_score_player_two ( std::move ( game_score_two ) )
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
