#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IGame.h"
#include "IGames.h"

class MockIGames
        : public Tennis::Logic::IGames
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(create_new_game,
        Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD0(get_current_game,
        Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD1(get_game_at_index,
        Tennis::Logic::IGame_Ptr(const size_t index));
    MOCK_CONST_METHOD0(get_number_of_games,
        size_t());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
