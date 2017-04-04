#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IAwardPoints.h"
#include "IGameScore.h"

class MockIAwardPoints
        :public Tennis::Logic::IAwardPoints
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD3(awardPoint,
        void(
            const Tennis::Logic::Player player,
            Tennis::Logic::IGameScore* scorePlayerOne,
            Tennis::Logic::IGameScore* scorePlayerTwo));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
