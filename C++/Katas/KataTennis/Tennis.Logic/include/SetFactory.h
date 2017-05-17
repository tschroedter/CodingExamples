#pragma once
#include "ISet.h"
#include "TieBreakFactory.h"
#include "ISetFactory.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class SetFactory 
            : public ISetFactory
        {
        private:
            std::unique_ptr<GameFactory> m_game_factory;
            std::unique_ptr<TieBreakFactory> m_tie_break_factory;

        public:
            SetFactory (
                std::unique_ptr<GameFactory> game_factory,
                std::unique_ptr<TieBreakFactory> tie_break_factory )
=======
        class SetFactory
                : public ISetFactory
        {
        private:
            std::shared_ptr<IGameFactory> m_game_factory;
            std::shared_ptr<ITieBreakFactory> m_tie_break_factory;

        public:
            SetFactory (
                std::shared_ptr<IGameFactory> game_factory,
                std::shared_ptr<ITieBreakFactory> tie_break_factory )
>>>>>>> Update from private repository
                : m_game_factory ( std::move ( game_factory ) )
                , m_tie_break_factory ( std::move ( tie_break_factory ) )
            {
            }

<<<<<<< HEAD
            ISet* create ();
            void release(ISet* set);
=======
            ~SetFactory ()
            {
                m_game_factory.reset();
                m_tie_break_factory.reset();
            }

            ISet* create () override;
            void release ( ISet* set ) override;
>>>>>>> Update from private repository
        };
    }
}
