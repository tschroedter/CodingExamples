#pragma once

<<<<<<< HEAD
=======
#include <string>

>>>>>>> Update from private repository
namespace Tennis
{
    namespace Logic
    {
        class IPlayerNameManager
        {
        public:
            virtual ~IPlayerNameManager () = default;

<<<<<<< HEAD
            virtual std::string get_player_name ( Player player ) const = 0;
        };
=======
            virtual const std::string get_player_name ( const Player player ) const = 0;
            virtual void set_player_name ( const Player player, const std::string name ) = 0;
        };

        typedef std::shared_ptr<IPlayerNameManager> IPlayerNameManager_Ptr;
>>>>>>> Update from private repository
    };
};
