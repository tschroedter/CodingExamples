#pragma once

#include "Game.h"
#include "IPlayerNameManager.h"

namespace Tennis
{
    namespace Logic
    {
        class PlayerNameManager // todo singelton
                : public IPlayerNameManager
        {
        private:
            std::string m_player_name_one = "Player One";
            std::string m_player_name_two = "Player Two";
            const ILogger* m_logger;

        public:
            PlayerNameManager (
                const ILogger* logger,
                const std::string player_name_one,
                const std::string player_name_two )
                : m_player_name_one ( player_name_one )
                , m_player_name_two ( player_name_two )
                , m_logger ( logger )
            {
            }

            std::string PlayerNameManager::get_player_name ( Player player ) const override;
        };
    };
};
