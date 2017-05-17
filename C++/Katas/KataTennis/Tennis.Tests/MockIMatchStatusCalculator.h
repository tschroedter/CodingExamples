#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IMatchStatusCalculator.h"

class MockIMatchStatusCalculator
        :public Tennis::Logic::IMatchStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::MatchStatus());
    MOCK_METHOD1(initialize, void(const Tennis::Logic::ISets_Ptr));
    MOCK_METHOD1(set_required_sets_to_win, void(const Tennis::Logic::RequiredSetsToWin));
    MOCK_METHOD0(get_required_sets_to_win, const Tennis::Logic::RequiredSetsToWin());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
