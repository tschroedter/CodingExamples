#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ICountPlayerGames.h"
#include "IGames.h"
#include "ITieBreak.h"

class MockICountPlayerGames
        :public Tennis::Logic::ICountPlayerGames
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD3(
        count_games,
        std::string(
            const Tennis::Logic::Player player,
            const Tennis::Logic::IGames_Ptr games,
            const Tennis::Logic::ITieBreak_Ptr tie_brea));
    MOCK_CONST_METHOD3(
        calculate_games,
        int8_t(
            const Tennis::Logic::Player player,
            const Tennis::Logic::IGames_Ptr games,
            const Tennis::Logic::ITieBreak_Ptr tie_brea));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
