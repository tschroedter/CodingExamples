#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IGameScore.h"

class MockIGameScore
        :public Tennis::Logic::IGameScore
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(toString, std::string());
    MOCK_METHOD0(wonPoint, void());
    MOCK_METHOD0(losePoint, void());
    MOCK_CONST_METHOD0(getScore, Tennis::Logic::Scores());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
