#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ILogger.h"

class MockILogger
        :public Tennis::Logic::ILogger
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
<<<<<<< HEAD
    MOCK_CONST_METHOD1(debug, void(std::string message));
    MOCK_CONST_METHOD1(error, void(std::string message));
    MOCK_CONST_METHOD1(info, void(std::string message));
=======
    MOCK_CONST_METHOD1(debug, void(const std::string message));
    MOCK_CONST_METHOD1(error, void(const std::string message));
    MOCK_CONST_METHOD1(info, void(const std::string message));
    MOCK_CONST_METHOD1(warning, void(const std::string message));
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
