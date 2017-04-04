#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISets.h"
#include "MockISet.h"

class MockISets
    : public Tennis::Logic::ISets
{
public:
    size_t mock_get_length_value = -1;

    std::vector<Tennis::Logic::ISet*> sets;

    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(new_set, Tennis::Logic::ISet*());
    MOCK_CONST_METHOD0(get_current_set, Tennis::Logic::ISet*());
    //MOCK_CONST_METHOD1(operator[], IGame* (const size_t)); // todo how to mock operators
    // virtual IGame* operator[] (const size_t index) const = 0;
    Tennis::Logic::ISet* operator[] (const size_t index) const
    {
        return (sets.at(index));
    };
    //MOCK_CONST_METHOD0(get_length, size_t());
    size_t get_length() const // todo testing
    {
        if (mock_get_length_value == -1)
        {
            return sets.size();
        }

        return mock_get_length_value;
    }
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
