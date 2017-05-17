#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISetStatusCalculator.h"

class MockISetStatusCalculator
        :public Tennis::Logic::ISetStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(get_status, const Tennis::Logic::SetStatus(
        const Tennis::Logic::IGames_Ptr games,
        const Tennis::Logic::ITieBreak_Ptr tie_break));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
