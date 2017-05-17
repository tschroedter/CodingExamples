#pragma once

#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "Sets.h"
#include "MockISetFactory.h"

class MockSets
        : public Tennis::Logic::Sets
{
public:
    MockSets ()
        : Sets ( std::move ( factory ) )
    {
    }

    std::unique_ptr<MockISetFactory> factory = std::make_unique<MockISetFactory>();

    size_t mock_get_length_value = -1;

    std::vector<Tennis::Logic::ISet*> sets;

    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(new_item, Tennis::Logic::ISet*());
    MOCK_CONST_METHOD0(get_current_item, Tennis::Logic::ISet*());
    //MOCK_CONST_METHOD1(operator[], IGame* (const size_t));
    // virtual IGame* operator[] (const size_t index) const = 0;
    Tennis::Logic::ISet* operator[] ( const size_t index ) const
    {
        return ( sets.at ( index ) );
    };
    //MOCK_CONST_METHOD0(get_length, size_t());
    size_t get_length () const
    {
        if ( mock_get_length_value == -1 )
        {
            return sets.size();
        }

        return mock_get_length_value;
    }

    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
