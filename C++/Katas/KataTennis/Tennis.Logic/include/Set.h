#pragma once
#include "Game.h"
#include "Games.h"
#include "ISet.h"
#include "ITieBreak.h"
#include "ISetWonPointHandler.h"
#include "ISetStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        class Set
                : public ISet
        {
        private:
            std::unique_ptr<ISetStatusCalculator> m_calculator;
            std::unique_ptr<ISetWonPointHandler> m_handler;
            std::unique_ptr<IGames> m_games;
            std::unique_ptr<ITieBreak> m_tie_break;

        public:
            Set ( 
                std::unique_ptr<ISetStatusCalculator> calculator, // todo use this
                std::unique_ptr<ISetWonPointHandler> handler,
                std::unique_ptr<IGames> games,
                std::unique_ptr<ITieBreak> tie_break )
                : m_calculator ( std::move ( calculator ))
                , m_handler ( std::move ( handler ) )
                , m_games ( std::move ( games ) )
                , m_tie_break ( std::move ( tie_break ) )
            {
                m_games->new_game(); // todo need empty constructor
            }

            ~Set ()
            {
            }

            void won_point ( Player player ) override;
            IGame* get_current_game () const override;
            const IGames* get_games () const override;
            size_t get_games_length () const override;
            const ITieBreak* get_tie_break () const override;
            const SetStatus Set::get_status() const override;
        };
    }
};
