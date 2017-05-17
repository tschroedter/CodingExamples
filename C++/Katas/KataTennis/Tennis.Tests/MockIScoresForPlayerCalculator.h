#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "Sets.h"
#include "IScoresForPlayerCalculator.h"

class MockIScoresForPlayerCalculator
        :public Tennis::Logic::IScoresForPlayerCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(
        get_scores_for_player,
        std::string(
            const Tennis::Logic::Player,
            const Tennis::Logic::ISets_Ptr));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
