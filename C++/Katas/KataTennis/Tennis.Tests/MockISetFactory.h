#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISetFactory.h"

class MockISetFactory
    : public Tennis::Logic::ISetFactory
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(create, Tennis::Logic::ISet*());
    MOCK_METHOD1(release, void(Tennis::Logic::ISet*));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};