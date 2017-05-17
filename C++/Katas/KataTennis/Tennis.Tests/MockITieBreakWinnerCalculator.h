#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ITieBreakWinnerCalculator.h"

class MockITieBreakWinnerCalculator
        :public Tennis::Logic::ITieBreakWinnerCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(was_tie_break_won_by_player,
        bool(
            const Tennis::Logic::ITieBreak_Ptr tie_break,
            const Tennis::Logic::Player player));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
