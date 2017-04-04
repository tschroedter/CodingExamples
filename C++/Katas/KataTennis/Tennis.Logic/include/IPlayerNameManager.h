#pragma once

namespace Tennis
{
    namespace Logic
    {
        class IPlayerNameManager
        {
        public:
            virtual ~IPlayerNameManager () = default;

            virtual std::string get_player_name ( Player player ) const = 0;
        };
    };
};
