#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IGames.h"
#include "IGamesCounter.h"

class MockIGamesCounter
        :public Tennis::Logic::IGamesCounter
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD2(count_games_for_player,
        int8_t(const Tennis::Logic::Player player,
            const Tennis::Logic::IGames_Ptr games));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
