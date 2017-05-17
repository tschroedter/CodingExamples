#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IGame.h"
#include "IGames.h"
<<<<<<< HEAD
#include "MockIGame.h"
=======
>>>>>>> Update from private repository

class MockIGames
        : public Tennis::Logic::IGames
{
public:
<<<<<<< HEAD
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
=======
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_METHOD0(create_new_game,
        Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD0(get_current_game,
        Tennis::Logic::IGame_Ptr());
    MOCK_CONST_METHOD1(get_game_at_index,
        Tennis::Logic::IGame_Ptr(const size_t index));
    MOCK_CONST_METHOD0(get_number_of_games,
        size_t());
>>>>>>> Update from private repository
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
