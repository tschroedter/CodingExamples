#pragma once
#include "Game.h"
<<<<<<< HEAD
#include "Games.h"
=======
#include "IGames.h"
>>>>>>> Update from private repository
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
<<<<<<< HEAD
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
=======
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
>>>>>>> Update from private repository
            }

            ~Set ()
            {
            }

<<<<<<< HEAD
            void won_point ( Player player ) override;
            IGame* get_current_game () const override;
            const IGames* get_games () const override;
            size_t get_games_length () const override;
            const ITieBreak* get_tie_break () const override;
            const SetStatus Set::get_status() const override;
=======
            void initialize () override;
            void won_point ( Player player ) override;
            IGame_Ptr get_current_game () const override;
            const IGames_Ptr get_games () const override;
            size_t get_games_length () const override;
            const ITieBreak_Ptr get_tie_break () const override;
            const SetStatus Set::get_status () const override;
            const TieBreakStatus get_tie_break_status () const override;
>>>>>>> Update from private repository
        };
    }
};
