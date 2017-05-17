#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
<<<<<<< HEAD
#include "ISets.h"
#include "IMatchStatusCalculator.h"

class MockIMatchStatusCalculator
    :public Tennis::Logic::IMatchStatusCalculator
=======
#include "IMatchStatusCalculator.h"

class MockIMatchStatusCalculator
        :public Tennis::Logic::IMatchStatusCalculator
>>>>>>> Update from private repository
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::MatchStatus());
<<<<<<< HEAD
=======
    MOCK_METHOD1(initialize, void(const Tennis::Logic::ISets_Ptr));
    MOCK_METHOD1(set_required_sets_to_win, void(const Tennis::Logic::RequiredSetsToWin));
    MOCK_METHOD0(get_required_sets_to_win, const Tennis::Logic::RequiredSetsToWin());
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
