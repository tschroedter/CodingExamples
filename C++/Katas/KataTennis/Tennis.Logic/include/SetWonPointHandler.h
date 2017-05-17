#pragma once

#include "ISetWonPointHandler.h"
#include "IGamesCounter.h"
#include <cstdint>
#include "ITieBreak.h"
#include <memory>

namespace Tennis
{
    namespace Logic
    {
        class SetWonPointHandler
                : public ISetWonPointHandler
        {
        private:
            static const bool WonGamePoint = false;
            static const bool WonTieBreakPoint = true;
            static const int8_t MAX_GAME_SCORE = 6;

<<<<<<< HEAD
            IGames* m_games;
            ITieBreak* m_tie_break;
            std::unique_ptr<IGamesCounter> m_counter;

        public:
            SetWonPointHandler (
                std::unique_ptr<IGamesCounter> counter,
                IGames* games,
                ITieBreak* tie_break )
                : m_games ( games )
                , m_tie_break ( tie_break )
                , m_counter ( std::move ( counter ) )
=======
            IGamesCounter_Ptr m_counter;
            IGames_Ptr m_games;
            ITieBreak_Ptr m_tie_break;

        public:
            SetWonPointHandler (
                IGamesCounter_Ptr counter )
                : m_counter ( counter )
>>>>>>> Update from private repository
            {
            }

            ~SetWonPointHandler ()
            {
            }

<<<<<<< HEAD
            void won_game_point( Player player ) const override;
            void won_tie_break_point( Player player ) const override;
            void won_point( Player player ) const override;
            bool is_tie_break_Required() const override;
=======
            void intitialize ( const IGames_Ptr games, const ITieBreak_Ptr tie_break ) override;
            void won_game_point ( const Player player ) const override;
            void won_tie_break_point ( const Player player ) const override;
            void won_point ( const Player player ) const override;
            bool is_tie_break_Required () const override;
>>>>>>> Update from private repository
        };
    }
}
