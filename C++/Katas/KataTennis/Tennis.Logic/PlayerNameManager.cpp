#include "include/PlayerNameManager.h"
#include <string>
#include "include/PlayerException.h"

namespace Tennis
{
    namespace Logic
    {
        const std::string PlayerNameManager::get_player_name ( const Player player ) const
        {
            switch ( player )
            {
                case One :
                    return m_player_name_one;
                case Two :
                    return m_player_name_two;
                default :
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
            }
        }
    };
};
