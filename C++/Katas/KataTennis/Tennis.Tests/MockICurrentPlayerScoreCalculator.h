#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISet.h"
#include "ICurrentPlayerScoreCalculator.h"

class MockICurrentPlayerScoreCalculator
        :public Tennis::Logic::ICurrentPlayerScoreCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(
        get_current_score_for_player,
        std::string(const Tennis::Logic::Player player,
            const Tennis::Logic::ISet_Ptr set));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
