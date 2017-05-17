#pragma once
#include "IMatch.h"
#include "RequiredSetsToWin.h"
#include "Player.h"
#include <memory>
#include "ISets.h"
#include "IMatchStatusCalculator.h"
<<<<<<< HEAD
#include "IMatchWonPointHandler.h"
=======
#include "ILogger.h"
#include "MatchWonPointHandler.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
        class Match
                : public IMatch
        {
        private:
<<<<<<< HEAD
            std::unique_ptr<IMatchWonPointHandler> m_handler;
            std::unique_ptr<IMatchStatusCalculator> m_calculator;
            RequiredSetsToWin m_required_sets_to_win;
            std::unique_ptr<ISets> m_sets;

        public:
            Match (
                std::unique_ptr<IMatchWonPointHandler> handler,
                std::unique_ptr<IMatchStatusCalculator> calculator,
                std::unique_ptr<ISets> sets,
                RequiredSetsToWin required_sets_to_win )
                : m_handler ( std::move( handler ) )
                , m_calculator ( std::move ( calculator ) )
                , m_required_sets_to_win ( required_sets_to_win )
                , m_sets ( std::move ( sets ) )
=======
            ILogger_Ptr m_logger;
            IMatchWonPointHandler_Ptr m_handler;
            IMatchStatusCalculator_Ptr m_calculator;
            ISets_Ptr m_sets;
            RequiredSetsToWin m_required_sets_to_win;

        public:
            Match (
                ILogger_Ptr logger,
                IMatchWonPointHandler_Ptr handler,
                IMatchStatusCalculator_Ptr calculator,
                ISets_Ptr sets )
                : m_logger ( logger )
                , m_handler ( handler )
                , m_calculator ( calculator )
                , m_sets ( sets )
                , m_required_sets_to_win ( RequiredSetsToWin_Two )
>>>>>>> Update from private repository
            {
            }

            ~Match ()
            {
            }

            void initialize () override;
<<<<<<< HEAD
            void won_point ( Player player ) override;
            MatchStatus get_status () const override;
            RequiredSetsToWin get_required_sets_to_win () const override;
            ISets* get_sets() const override;
        };
=======
            void won_point ( const Player player ) override;
            MatchStatus get_status () const override;
            RequiredSetsToWin get_required_sets_to_win () const override;
            ISets_Ptr get_sets () const override;
        };

        typedef std::shared_ptr<IMatch> IMatch_Ptr;
>>>>>>> Update from private repository
    };
};
