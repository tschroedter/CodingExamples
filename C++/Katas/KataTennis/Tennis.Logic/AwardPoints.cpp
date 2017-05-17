#include "include/Player.h"
#include "include/AwardPoints.h"
#include "include/IGameScore.h"
#include <string>
<<<<<<< HEAD
=======
#include "include/PlayerException.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        void AwardPoints::award_point (
            const Player player,
            IGameScore* scorePlayerOne,
            IGameScore* scorePlayerTwo )
        {
            switch ( player )
            {
                case One :
                    if ( Advantage == scorePlayerTwo->get_score() )
                    {
                        scorePlayerTwo->lost_point();
                        return;
                    }
                    break;
                case Two :
                    if ( Advantage == scorePlayerOne->get_score() )
                    {
                        scorePlayerOne->lost_point();
                        return;
                    }
                    break;
                default :
<<<<<<< HEAD
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) );
                    break;
=======
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
>>>>>>> Update from private repository
            }

            switch ( player )
            {
                case One :
                    scorePlayerOne->won_point();
                    break;

                case Two :
                    scorePlayerTwo->won_point();
                    break;

                default :
<<<<<<< HEAD
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) ); // todo exceptions
                    break;
=======
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
>>>>>>> Update from private repository
            }
        }
    };
};
