#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "IMatchWonPointHandler.h"

class MockIMatchWonPointHandler
<<<<<<< HEAD
    :public Tennis::Logic::IMatchWonPointHandler
=======
        :public Tennis::Logic::IMatchWonPointHandler
>>>>>>> Update from private repository
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD1(won_point, void(const Tennis::Logic::Player));
<<<<<<< HEAD
=======
    MOCK_METHOD1(initialize, void(const Tennis::Logic::ISets_Ptr));
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
