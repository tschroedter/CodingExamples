#pragma once
#include "IMatch.h"
#include "RequiredSetsToWin.h"
#include "Player.h"
#include <memory>
#include "ISets.h"
#include "IMatchStatusCalculator.h"
#include "ILogger.h"
#include "MatchWonPointHandler.h"

namespace Tennis
{
    namespace Logic
    {
        class Match
                : public IMatch
        {
        private:
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
            {
            }

            ~Match ()
            {
            }

            void initialize () override;
            void won_point ( const Player player ) override;
            MatchStatus get_status () const override;
            RequiredSetsToWin get_required_sets_to_win () const override;
            ISets_Ptr get_sets () const override;
        };

        typedef std::shared_ptr<IMatch> IMatch_Ptr;
    };
};
