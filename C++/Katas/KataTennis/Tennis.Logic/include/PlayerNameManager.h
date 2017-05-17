#pragma once

#include "Game.h"
#include "IPlayerNameManager.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> Update from private repository
        };
    };
};
