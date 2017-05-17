#pragma once

#pragma once
#include <memory>
#include "IMatch.h"
<<<<<<< HEAD
#include "MatchStatusCalculator.h"
#include "MatchWonPointHandler.h"
#include "MatchCounter.h"
#include "Sets.h"
#include <iostream>
#include "Logger.h"
#include "Match.h"
=======
>>>>>>> Update from private repository
#include "IMatchFactory.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class MatchFactory  // todo testing
            : public IMatchFactory
        {
        public:
            MatchFactory()
            {
            }

            ~MatchFactory()
            {
            }

            std::unique_ptr<Tennis::Logic::IMatch> create()
            {
                using namespace Tennis::Logic;

                std::unique_ptr<GameFactory> game_factory = std::make_unique<GameFactory>();
                std::unique_ptr<ILogger> tie_break_logger = std::make_unique<Logger>(std::cout);
                std::unique_ptr<TieBreakFactory> tie_break_factory = std::make_unique<TieBreakFactory>(std::move(tie_break_logger));
                SetFactory* p_set_factory =
                    new SetFactory
                    (
                        std::move(game_factory),
                        std::move(tie_break_factory)
                    );
                std::unique_ptr<ISetFactory> set_factory(p_set_factory);

                std::unique_ptr<ISets> sets = std::make_unique<Sets>
                    (
                        std::move(set_factory)
                        );

                std::unique_ptr<IMatchCounter> match_counter = std::make_unique<MatchCounter>();

                std::unique_ptr<IMatchWonPointHandler> handler = std::make_unique<MatchWonPointHandler>
                    (
                        sets.get()
                        );

                std::unique_ptr<IMatchStatusCalculator> match_calculator = std::make_unique<MatchStatusCalculator>
                    (
                        std::move(match_counter),
                        sets.get(), // todo maybe shared_ptr
                        RequiredSetsToWin_Two
                        );

                Tennis::Logic::Match* match = new Tennis::Logic::Match
                {
                    std::move(handler),
                    std::move(match_calculator),
                    std::move(sets),
                    RequiredSetsToWin_Two
                };

                match->initialize();

                std::unique_ptr<IMatch> p_match(match);

                return p_match;
            }
=======
        class MatchFactory
                : public IMatchFactory
        {
        public:
            MatchFactory ()
            {
            }

            ~MatchFactory ()
            {
            }

            std::unique_ptr<Tennis::Logic::IMatch> create () override;
>>>>>>> Update from private repository
        };
    }
}
