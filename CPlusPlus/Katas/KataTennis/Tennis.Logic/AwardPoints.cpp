#include "include/Player.h"
#include "include/AwardPoints.h"
#include "include/IGameScore.h"
#include <string>

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
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) );
                    break;
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
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) ); // todo exceptions
                    break;
            }
        }
    };
};
