#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "ISetWonPointHandler.h"

class MockISetWonPointHandler
        :public Tennis::Logic::ISetWonPointHandler
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD1(won_game_point, void (Tennis::Logic::Player));
    MOCK_CONST_METHOD1(won_tie_break_point, void(Tennis::Logic::Player));
    MOCK_CONST_METHOD1(won_point, void(Tennis::Logic::Player));
    MOCK_CONST_METHOD0(is_tie_break_Required, bool());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
