#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
#include "Sets.h"
#include "MockISet.h"

std::function<std::shared_ptr<Tennis::Logic::ISet> ()> create_factory ()
{
    return []
            {
                return std::make_shared<MockISet>();
            };
}

Hypodermic::FactoryWrapper<Tennis::Logic::ISet> wrapper { create_factory() };

TEST(Sets, create_new_set_returns_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    Sets sut { wrapper };

    // Act
    ISet_Ptr actual = sut.create_new_set();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Sets, create_new_set_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };

    Sets sut { wrapper };

    // Act
    sut.create_new_set();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Sets, get_number_of_sets_returns_number_of_Sets)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 2 };

    Sets sut { wrapper };

    sut.create_new_set();
    sut.create_new_set();

    // Act
    size_t actual = sut.get_number_of_sets();

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(Sets, get_current_set_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    Sets sut { wrapper };
    ISet_Ptr expected = sut.create_new_set();

    auto first = sut.create_new_set();
    auto second = sut.create_new_set();

    // Act
    auto actual = sut.get_current_set();

    // Assert
    EXPECT_EQ(second, actual);
}
