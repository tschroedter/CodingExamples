#include <algorithm>
#include "include/Game.h"
<<<<<<< HEAD
#include "GameFactory.h"
=======
#include "include/GameFactory.h"
>>>>>>> Update from private repository
#include "include/Logger.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        IGame* GameFactory::create () const
        {
            std::unique_ptr<ILogger> logger = std::make_unique<Logger> ( std::cout );
            std::unique_ptr<ILogger> loggerAwardPoints = std::make_unique<Logger> ( std::cout );
            std::unique_ptr<IAwardPoints> award_points ( m_factory.create() );
=======
        IGame* GameFactory::create ()
        {
            std::unique_ptr<IAwardPoints> award_points = m_factory->create();
>>>>>>> Update from private repository
            std::unique_ptr<IGameScore> game_score_one = std::make_unique<GameScore>();
            std::unique_ptr<IGameScore> game_score_two = std::make_unique<GameScore>();

            IGame* game = new Game{
<<<<<<< HEAD
                std::move ( logger ),
=======
>>>>>>> Update from private repository
                std::move ( award_points ),
                std::move ( game_score_one ),
                std::move ( game_score_two ) };

            return game;
        }

        void GameFactory::release ( IGame* game )
        {
            delete game;
        }
    }
}
