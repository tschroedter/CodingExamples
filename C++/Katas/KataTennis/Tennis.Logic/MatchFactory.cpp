#pragma once

#include <memory>
#include <iostream>
#include "include/SetFactory.h"
#include "include/Logger.h"
#include "include/Sets.h"
#include "include/IMatchCounter.h"
#include "include/MatchCounter.h"
#include "include/MatchFactory.h"
#include "include/IMatchWonPointHandler.h"
#include "include/MatchWonPointHandler.h"
#include "include/IMatchStatusCalculator.h"
#include "include/MatchStatusCalculator.h"
#include "include/Match.h"
#include "include/IAwardPointsFactory.h"
#include "include/AwardPointsFactory.h"
#include "include/GameFactory.h"

namespace Tennis
{
    namespace Logic
    {
        std::unique_ptr<IMatch> MatchFactory::create ()
        {
            std::shared_ptr<IAwardPointsFactory> award_points_factory = std::make_shared<AwardPointsFactory>();
            std::shared_ptr<IGameFactory> game_factory = std::make_shared<GameFactory> ( move ( award_points_factory ) );
            std::shared_ptr<ITieBreakFactory> tie_break_factory = std::make_shared<TieBreakFactory> ();
            SetFactory* p_set_factory = new SetFactory (
                                                        move ( game_factory ),
                                                        move ( tie_break_factory )
                                                       );
            std::shared_ptr<ISetFactory> set_factory ( p_set_factory );

            std::unique_ptr<ISets> sets = std::make_unique<Sets>
            (
             move ( set_factory )
            );

            std::unique_ptr<IMatchCounter> match_counter = std::make_unique<MatchCounter>();

            std::unique_ptr<IMatchWonPointHandler> handler = std::make_unique<MatchWonPointHandler>
            (
             sets.get()
            );

            std::unique_ptr<IMatchStatusCalculator> match_calculator = std::make_unique<MatchStatusCalculator>
            (
             move ( match_counter ),
             sets.get(), // todo maybe shared_ptr
             RequiredSetsToWin_Two
            );

            std::unique_ptr<ILogger> logger = std::make_unique<Logger>(std::cout);

            Match* match = new Match
            {
                move ( logger ),
                move ( handler ),
                move ( match_calculator ),
                move ( sets ),
                RequiredSetsToWin_Two
            };

            match->initialize();

            std::unique_ptr<IMatch> p_match ( match );

            return p_match;
        }
    }
}
