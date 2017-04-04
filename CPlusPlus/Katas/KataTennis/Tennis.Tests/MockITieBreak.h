#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ITieBreak.h"

class MockITieBreak
        : public Tennis::Logic::ITieBreak
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD1(won_point, void(Tennis::Logic::Player));
    MOCK_CONST_METHOD1(get_score, uint8_t(Tennis::Logic::Player));
    MOCK_CONST_METHOD0(get_status, Tennis::Logic::TieBreakStatus());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
