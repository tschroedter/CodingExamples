#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ILogger.h"

class MockILogger
        :public Tennis::Logic::ILogger
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD1(debug, void(std::string message));
    MOCK_CONST_METHOD1(error, void(std::string message));
    MOCK_CONST_METHOD1(info, void(std::string message));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
