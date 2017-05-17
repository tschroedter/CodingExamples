#include "stdafx.h"
#include <Hypodermic/ContainerBuilder.h>
#include "IGameScore.h"
#include "IIOCContainerBuilder.h"
#include "IOCContainerBuilder.h"
#include "GameScore.h"
#include "IAwardPoints.h"
#include "AwardPoints.h"
#include "ICountPlayerGames.h"
#include "CountPlayerGames.h"
#include "GamesCounter.h"
#include "TieBreakWinnerCalculator.h"
#include "ICurrentPlayerScoreCalculator.h"
#include "CurrentPlayerScoreCalculator.h"
#include "Game.h"
#include "Logger.h"
#include "IMatchCounter.h"
#include "MatchCounter.h"
#include "IMatchStatusCalculator.h"
#include "MatchStatusCalculator.h"
#include "IPlayerNameManager.h"
#include "PlayerNameManager.h"
#include "IScoresForPlayerCalculator.h"
#include "ScoresForPlayerCalculator.h"
#include "Set.h"
#include "SetStatusCalculator.h"
#include "SetWonPointHandler.h"
#include "Games.h"
#include "Sets.h"
#include "ISets.h"
#include "Match.h"
#include "TieBreak.h"
#include "ScoreBoard.h"

namespace Tennis
{
    namespace Match
    {
        void IOCContainerBuilder::register_components (
            Hypodermic::ContainerBuilder& builder )
        {
            using namespace Logic;

            builder.registerType<GameScore>()
                   .as<IGameScore>();

            builder.registerType<AwardPoints>()
                   .as<IAwardPoints>();

            builder.registerType<CountPlayerGames>()
                   .as<ICountPlayerGames>();

            builder.registerType<GamesCounter>()
                   .as<IGamesCounter>();

            builder.registerType<CurrentPlayerScoreCalculator>()
                   .as<ICurrentPlayerScoreCalculator>();

            builder.registerType<Game>()
                   .as<IGame>();

            builder.registerType<Games>()
                   .as<IGames>();

            builder.registerType<Sets>()
                   .as<ISets>();

            builder.registerType<GamesCounter>()
                   .as<IGamesCounter>();

            builder.registerType<Logger>()
                   .as<ILogger>();

            builder.registerType<MatchCounter>()
                   .as<IMatchCounter>();

            builder.registerType<MatchStatusCalculator>()
                   .as<IMatchStatusCalculator>();

            builder.registerType<MatchWonPointHandler>()
                   .as<IMatchWonPointHandler>();

            builder.registerType<PlayerNameManager>()
                   .as<IPlayerNameManager>();

            builder.registerType<ScoresForPlayerCalculator>()
                   .as<IScoresForPlayerCalculator>();

            builder.registerType<Set>()
                   .as<ISet>();

            builder.registerType<TieBreak>()
                   .as<ITieBreak>();

            builder.registerType<TieBreakScore>()
                   .as<ITieBreakScore>();

            builder.registerType<TieBreakWinnerCalculator>()
                   .as<ITieBreakWinnerCalculator>();

            builder.registerType<SetWonPointHandler>()
                   .as<ISetWonPointHandler>();

            builder.registerType<SetStatusCalculator>()
                   .as<ISetStatusCalculator>();

            builder.registerType<Logic::Match>()
                   .as<IMatch>();

            builder.registerType<ScoreBoard>()
                   .as<IScoreBoard>();
        }

        Container_Ptr IOCContainerBuilder::build ()
        {
            Hypodermic::ContainerBuilder builder;

            using namespace Logic;
            {
                register_components ( builder );

                Container_Ptr container = builder.build();

                return container;
            }
        }
    };
};
