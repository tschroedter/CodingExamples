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
            IMatchCounter_Ptr m_counter;
            ISets_Ptr m_sets;
            RequiredSetsToWin m_required_sets_to_win;

        public:
            MatchStatusCalculator (
                IMatchCounter_Ptr counter,
                RequiredSetsToWin required_sets_to_win = RequiredSetsToWin_Two )
                : m_counter ( counter )
                , m_required_sets_to_win ( required_sets_to_win )
            {
            }

            ~MatchStatusCalculator ()
            {
            }

            void initialize ( const ISets_Ptr sets ) override;
            const MatchStatus get_status () const override;
            void set_required_sets_to_win(RequiredSetsToWin required_sets_to_win) override;
            const RequiredSetsToWin get_required_sets_to_win() override;
        };
    };
};
