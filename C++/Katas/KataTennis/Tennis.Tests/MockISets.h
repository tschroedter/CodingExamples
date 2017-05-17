#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISet.h"
#include "ISets.h"

class MockISets
        : public Tennis::Logic::ISets
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(create_new_set, Tennis::Logic::ISet_Ptr());
    MOCK_CONST_METHOD0(get_current_set, Tennis::Logic::ISet_Ptr());
    MOCK_CONST_METHOD1(get_set_at_index, Tennis::Logic::ISet_Ptr(const size_t));
    MOCK_CONST_METHOD0(get_number_of_sets, size_t());
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
