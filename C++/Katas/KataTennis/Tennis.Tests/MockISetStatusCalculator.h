#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISetStatusCalculator.h"

class MockISetStatusCalculator
<<<<<<< HEAD
    :public Tennis::Logic::ISetStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::SetStatus());
=======
        :public Tennis::Logic::ISetStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(get_status, const Tennis::Logic::SetStatus(
        const Tennis::Logic::IGames_Ptr games,
        const Tennis::Logic::ITieBreak_Ptr tie_break));
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
