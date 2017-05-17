#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Player.h"
#include "Scores.h"
#include "GameStatus.h"
#include "IGame.h"

class MockIGame
        :public Tennis::Logic::IGame
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD1(won_point,
        void(const Tennis::Logic::Player));
    MOCK_CONST_METHOD0(get_status,
        Tennis::Logic::GameStatus());
    MOCK_CONST_METHOD1(get_score_for_player,
        Tennis::Logic::Scores(const Tennis::Logic::Player));
    MOCK_CONST_METHOD1(get_score_for_player_as_string,
        std::string(const Tennis::Logic::Player));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
