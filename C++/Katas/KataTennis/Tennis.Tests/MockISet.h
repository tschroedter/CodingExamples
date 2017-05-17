#pragma once
<<<<<<< HEAD
=======

>>>>>>> Update from private repository
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISet.h"
#include "Player.h"
<<<<<<< HEAD

class IGame;
class IGames;
=======
#include "IGame.h"
#include "IGames.h"
>>>>>>> Update from private repository

class MockISet
        :public Tennis::Logic::ISet
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
<<<<<<< HEAD
    MOCK_METHOD1(won_point, void(Tennis::Logic::Player player));
    MOCK_CONST_METHOD0(get_current_game, Tennis::Logic::IGame*());
    MOCK_CONST_METHOD0(get_games, Tennis::Logic::IGames*());
    MOCK_CONST_METHOD0(get_games_length, size_t());
    MOCK_CONST_METHOD0(get_tie_break, Tennis::Logic::ITieBreak*());
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
=======
    MOCK_METHOD0(initialize, void());
    MOCK_METHOD1(won_point, void(Tennis::Logic::Player player));
    MOCK_CONST_METHOD0(get_current_game, Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD0(get_games, const Tennis::Logic::IGames_Ptr());
    MOCK_CONST_METHOD0(get_games_length, size_t());
    MOCK_CONST_METHOD0(get_tie_break, const Tennis::Logic::ITieBreak_Ptr());
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
    MOCK_CONST_METHOD0(get_tie_break_status, const Tennis::Logic::TieBreakStatus());
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
