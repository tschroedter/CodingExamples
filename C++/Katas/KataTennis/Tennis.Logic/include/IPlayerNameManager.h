#pragma once

#include <string>

namespace Tennis
{
    namespace Logic
    {
        class IPlayerNameManager
        {
        public:
            virtual ~IPlayerNameManager () = default;

            virtual const std::string get_player_name ( const Player player ) const = 0;
            virtual void set_player_name ( const Player player, const std::string name ) = 0;
        };

        typedef std::shared_ptr<IPlayerNameManager> IPlayerNameManager_Ptr;
    };
};
