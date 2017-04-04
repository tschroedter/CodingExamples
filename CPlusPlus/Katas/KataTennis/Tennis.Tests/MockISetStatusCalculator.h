#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISetStatusCalculator.h"

class MockISetStatusCalculator
    :public Tennis::Logic::ISetStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
