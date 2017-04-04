#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISet.h"
#include "Player.h"

class IGame;
class IGames;

class MockISet
        :public Tennis::Logic::ISet
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD1(won_point, void(Tennis::Logic::Player player));
    MOCK_CONST_METHOD0(get_current_game, Tennis::Logic::IGame*());
    MOCK_CONST_METHOD0(get_games, Tennis::Logic::IGames*());
    MOCK_CONST_METHOD0(get_games_length, size_t());
    MOCK_CONST_METHOD0(get_tie_break, Tennis::Logic::ITieBreak*());
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
