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
    MOCK_METHOD2(intitialize,
        void(const Tennis::Logic::IGames_Ptr, const Tennis::Logic::ITieBreak_Ptr ));
    MOCK_CONST_METHOD1(won_game_point, void (const Tennis::Logic::Player));
    MOCK_CONST_METHOD1(won_tie_break_point, void(const Tennis::Logic::Player));
    MOCK_CONST_METHOD1(won_point, void(const Tennis::Logic::Player));
    MOCK_CONST_METHOD0(is_tie_break_Required, bool());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
