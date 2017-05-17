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
    MOCK_METHOD1(initialize, void(const Tennis::Logic::ISets_Ptr));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
