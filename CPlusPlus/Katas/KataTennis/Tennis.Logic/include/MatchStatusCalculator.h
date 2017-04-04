#pragma once
#include "IMatchStatusCalculator.h"
#include "IMatchCounter.h"
#include <memory>
#include "ISets.h"
#include "RequiredSetsToWin.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchStatusCalculator
                : public IMatchStatusCalculator
        {
        private:
            std::unique_ptr<IMatchCounter> m_counter;
            ISets* m_sets;
            RequiredSetsToWin m_required_sets_to_win;

        public:
            MatchStatusCalculator (
                std::unique_ptr<IMatchCounter> counter,
                ISets* sets,
                RequiredSetsToWin required_sets_to_win )
                : m_counter ( std::move ( counter ) )
                , m_sets ( sets )
                , m_required_sets_to_win ( required_sets_to_win )
            {
            }

            ~MatchStatusCalculator ()
            {
            }

            virtual const MatchStatus get_status () const override;
        };
    };
};
