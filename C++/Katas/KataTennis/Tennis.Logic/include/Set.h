#pragma once
#include "Game.h"
#include "IGames.h"
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
            ISetStatusCalculator_Ptr m_calculator;
            ISetWonPointHandler_Ptr m_handler;
            IGames_Ptr m_games;
            ITieBreak_Ptr m_tie_break;

        public:
            Set (
                ISetStatusCalculator_Ptr calculator,
                ISetWonPointHandler_Ptr handler,
                IGames_Ptr games,
                ITieBreak_Ptr tie_break )
                : m_calculator ( calculator )
                , m_handler ( handler )
                , m_games ( games )
                , m_tie_break ( tie_break )
            {
            }

            ~Set ()
            {
            }

            void initialize () override;
            void won_point ( Player player ) override;
            IGame_Ptr get_current_game () const override;
            const IGames_Ptr get_games () const override;
            size_t get_games_length () const override;
            const ITieBreak_Ptr get_tie_break () const override;
            const SetStatus Set::get_status () const override;
            const TieBreakStatus get_tie_break_status () const override;
        };
    }
};
