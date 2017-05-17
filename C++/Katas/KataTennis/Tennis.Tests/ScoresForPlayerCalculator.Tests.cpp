#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoresForPlayerCalculator.h"
#include "MockICurrentPlayerScoreCalculator.h"
#include "MockICountPlayerGames.h"
#include "MockISets.h"
#include "MockISet.h"
#include "MockITieBreak.h"
#include "MockIGames.h"

TEST(ScoresForPlayerCalculator, get_scores_for_player_returns_string_for_single_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games = new MockIGames{};
    IGames_Ptr games ( mock_games );
    MockITieBreak* mock_tie_break = new MockITieBreak{};
    ITieBreak_Ptr tie_break ( mock_tie_break );

    MockISet* mock_set = new MockISet{};
    ISet_Ptr set ( mock_set );
    MockISets* mock_sets = new MockISets{};
    ISets_Ptr sets ( mock_sets );

    MockICurrentPlayerScoreCalculator* mock_calculator = new MockICurrentPlayerScoreCalculator{};
    ICurrentPlayerScoreCalculator_Ptr calculator ( mock_calculator );

    MockICountPlayerGames* mock_count_player_games = new MockICountPlayerGames{};
    ICountPlayerGames_Ptr count_player_games ( mock_count_player_games );

    ScoresForPlayerCalculator sut
    {
        calculator,
        count_player_games
    };

    EXPECT_CALL(*mock_set, get_games())
                                       .Times ( 1 )
                                       .WillOnce ( testing::Return ( games ) );

    EXPECT_CALL(*mock_set, get_tie_break())
                                           .Times ( 1 )
                                           .WillOnce ( testing::Return ( tie_break ) );

    EXPECT_CALL(*mock_sets,
        get_number_of_sets())
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(*mock_sets,
        get_set_at_index(0))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( set ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One,
            games,
            tie_break))
                       .Times ( 1 )
                       .WillOnce ( testing::Return ( "3" ) );

    EXPECT_CALL(*mock_calculator,
        get_current_score_for_player(One, set))
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( "15" ) );

    // Act
    auto actual = sut.get_scores_for_player ( One,
                                              sets );

    // Assert
    EXPECT_EQ("3 15", actual);
}

TEST(ScoresForPlayerCalculator, get_scores_for_player_returns_string_for_multiple_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames* mock_games_one = new MockIGames{};
    IGames_Ptr games_one ( mock_games_one );
    MockITieBreak* mock_tie_break_one = new MockITieBreak{};
    ITieBreak_Ptr tie_break_one ( mock_tie_break_one );

    MockIGames* mock_games_two = new MockIGames{};
    IGames_Ptr games_two ( mock_games_two );
    MockITieBreak* mock_tie_break_two = new MockITieBreak{};
    ITieBreak_Ptr tie_break_two ( mock_tie_break_two );

    MockISet* mock_set_one = new MockISet{};
    ISet_Ptr set_one ( mock_set_one );
    MockISet* mock_set_two = new MockISet{};
    ISet_Ptr set_two ( mock_set_two );
    MockISets* mock_sets = new MockISets{};
    ISets_Ptr sets ( mock_sets );

    MockICurrentPlayerScoreCalculator* mock_calculator = new MockICurrentPlayerScoreCalculator{};
    ICurrentPlayerScoreCalculator_Ptr calculator ( mock_calculator );

    MockICountPlayerGames* mock_count_player_games = new MockICountPlayerGames{};
    ICountPlayerGames_Ptr count_player_games ( mock_count_player_games );

    ScoresForPlayerCalculator sut
    {
        calculator,
        count_player_games
    };

    EXPECT_CALL(*mock_set_one, get_games())
                                           .Times ( 1 )
                                           .WillOnce ( testing::Return ( games_one ) );

    EXPECT_CALL(*mock_set_one, get_tie_break())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( tie_break_one ) );

    EXPECT_CALL(*mock_set_two, get_games())
                                           .Times ( 1 )
                                           .WillOnce ( testing::Return ( games_two ) );

    EXPECT_CALL(*mock_set_two, get_tie_break())
                                               .Times ( 1 )
                                               .WillOnce ( testing::Return ( tie_break_two ) );

    EXPECT_CALL(*mock_sets,
        get_number_of_sets())
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( static_cast<size_t> ( 2 ) ) );

    EXPECT_CALL(*mock_sets,
        get_set_at_index(0))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( set_one ) );

    EXPECT_CALL(*mock_sets,
        get_set_at_index(1))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( set_two ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One,
            games_one,
            tie_break_one))
                           .Times ( 1 )
                           .WillOnce ( testing::Return ( "6" ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One,
            games_two,
            tie_break_two))
                           .Times ( 1 )
                           .WillOnce ( testing::Return ( "6" ) );

    EXPECT_CALL(*mock_calculator,
        get_current_score_for_player(One, set_two))
                                                   .Times ( 1 )
                                                   .WillOnce ( testing::Return ( "15" ) );

    // Act
    auto actual = sut.get_scores_for_player ( One,
                                              sets );

    // Assert
    EXPECT_EQ("6 6 15", actual);
}
