#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "IMatchCounter.h"
#include "Sets.h"

class MockIMatchCounter
        :public Tennis::Logic::IMatchCounter
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(count_sets_won_by_player,
        int8_t(const Tennis::Logic::Player,
            const Tennis::Logic::ISets_Ptr));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
