#pragma once
#include "ISet.h"
#include "TieBreakFactory.h"
#include "ISetFactory.h"

namespace Tennis
{
    namespace Logic
    {
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
                : m_game_factory ( std::move ( game_factory ) )
                , m_tie_break_factory ( std::move ( tie_break_factory ) )
            {
            }

            ISet* create ();
            void release(ISet* set);
        };
    }
}
