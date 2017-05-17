#include "include/PlayerNameManager.h"
#include <string>
<<<<<<< HEAD
=======
#include "include/PlayerException.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        std::string PlayerNameManager::get_player_name ( Player player ) const
=======
        const std::string PlayerNameManager::get_player_name ( const Player player ) const
>>>>>>> Update from private repository
        {
            switch ( player )
            {
                case One :
                    return m_player_name_one;
                case Two :
                    return m_player_name_two;
                default :
<<<<<<< HEAD
                    m_logger->error ( "Unknown Player type: " + std::to_string ( player ) );
                    return "Unknown";
=======
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
            }
        }

        void PlayerNameManager::set_player_name ( const Player player, const std::string name )
        {
            switch ( player )
            {
                case One :
                    m_player_name_one = name;
                    break;
                case Two :
                    m_player_name_two = name;
                    break;
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
>>>>>>> Update from private repository
            }
        }
    };
};
