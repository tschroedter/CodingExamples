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
<<<<<<< HEAD
            std::unique_ptr<IMatchCounter> m_counter;
            ISets* m_sets;
=======
            IMatchCounter_Ptr m_counter;
            ISets_Ptr m_sets;
>>>>>>> Update from private repository
            RequiredSetsToWin m_required_sets_to_win;

        public:
            MatchStatusCalculator (
<<<<<<< HEAD
                std::unique_ptr<IMatchCounter> counter,
                ISets* sets,
                RequiredSetsToWin required_sets_to_win )
                : m_counter ( std::move ( counter ) )
                , m_sets ( sets )
=======
                IMatchCounter_Ptr counter,
                RequiredSetsToWin required_sets_to_win = RequiredSetsToWin_Two )
                : m_counter ( counter )
>>>>>>> Update from private repository
                , m_required_sets_to_win ( required_sets_to_win )
            {
            }

            ~MatchStatusCalculator ()
            {
            }

<<<<<<< HEAD
            virtual const MatchStatus get_status () const override;
=======
            void initialize ( const ISets_Ptr sets ) override;
            const MatchStatus get_status () const override;
            void set_required_sets_to_win(RequiredSetsToWin required_sets_to_win) override;
            const RequiredSetsToWin get_required_sets_to_win() override;
>>>>>>> Update from private repository
        };
    };
};
