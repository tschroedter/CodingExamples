#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISet.h"
#include "Player.h"
#include "IGame.h"
#include "IGames.h"

class MockISet
        :public Tennis::Logic::ISet
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(initialize, void());
    MOCK_METHOD1(won_point, void(Tennis::Logic::Player player));
    MOCK_CONST_METHOD0(get_current_game, Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD0(get_games, const Tennis::Logic::IGames_Ptr());
    MOCK_CONST_METHOD0(get_games_length, size_t());
    MOCK_CONST_METHOD0(get_tie_break, const Tennis::Logic::ITieBreak_Ptr());
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
    MOCK_CONST_METHOD0(get_tie_break_status, const Tennis::Logic::TieBreakStatus());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
