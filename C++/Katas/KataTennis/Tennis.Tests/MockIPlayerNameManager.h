#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IPlayerNameManager.h"
#include "Player.h"

class MockIPlayerNameManager
        :public Tennis::Logic::IPlayerNameManager
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD1(get_player_name, std::string(Tennis::Logic::Player));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
