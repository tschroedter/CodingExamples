#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>

class MockIGameFactory
        : public Tennis::Logic::IGameFactory
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(create, Tennis::Logic::IGame*());
    MOCK_METHOD1(release, void(Tennis::Logic::IGame*));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
