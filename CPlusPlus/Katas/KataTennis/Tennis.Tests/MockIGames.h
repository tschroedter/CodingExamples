#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IGame.h"
#include "IGames.h"
#include "MockIGame.h"

class MockIGames
        : public Tennis::Logic::IGames
{
public:
    size_t mock_get_length_value = -1;

    std::vector<Tennis::Logic::IGame*> sets;

    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(new_game, Tennis::Logic::IGame*());
    MOCK_CONST_METHOD0(get_current_game, Tennis::Logic::IGame* ());
    //MOCK_CONST_METHOD1(operator[], IGame* (const size_t)); // todo how to mock operators
    // virtual IGame* operator[] (const size_t index) const = 0;
    Tennis::Logic::IGame* operator[] (const size_t index) const
    {
        return (sets.at(index));
    };

    // MOCK_CONST_METHOD0(get_length, size_t());
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
