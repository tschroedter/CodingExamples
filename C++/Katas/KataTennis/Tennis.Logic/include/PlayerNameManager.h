#pragma once

#include "Game.h"
#include "IPlayerNameManager.h"

namespace Tennis
{
    namespace Logic
    {
        class PlayerNameManager
                : public IPlayerNameManager
        {
        private:
            std::string m_player_name_one;
            std::string m_player_name_two;

        public:
            PlayerNameManager (
                std::string player_name_one = "Player One",
                std::string player_name_two = "Player Two" )
                : m_player_name_one ( player_name_one )
                , m_player_name_two ( player_name_two )
            {
            }

            ~PlayerNameManager ()
            {
            }

            const std::string PlayerNameManager::get_player_name ( const Player player ) const override;
            void PlayerNameManager::set_player_name ( const Player player, const std::string name ) override;
        };
    };
};
