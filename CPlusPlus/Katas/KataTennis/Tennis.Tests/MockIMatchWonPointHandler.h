#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "IMatchWonPointHandler.h"

class MockIMatchWonPointHandler
    :public Tennis::Logic::IMatchWonPointHandler
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD1(won_point, void(const Tennis::Logic::Player));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
