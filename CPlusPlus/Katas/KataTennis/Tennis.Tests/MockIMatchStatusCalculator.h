#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISets.h"
#include "IMatchStatusCalculator.h"

class MockIMatchStatusCalculator
    :public Tennis::Logic::IMatchStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::MatchStatus());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
