#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
#include "Container.h"

class Item
{
public:
    Item ()
    {
    }
};

typedef std::shared_ptr<Item> Item_Ptr;

std::function<std::shared_ptr<Item> ()> create_factory ()
{
    return []
            {
                return std::make_shared<Item>();
            };
}

Hypodermic::FactoryWrapper<Item> wrapper { create_factory() };

class TestContainer
        : public Tennis::Logic::Container<Item>
{
public:
    TestContainer (
        const Hypodermic::FactoryWrapper<Item>& factory_wrapper )
        : Container<Item> ( factory_wrapper )
    {
    }
};

std::unique_ptr<TestContainer> create_sut ()
{
    std::unique_ptr<TestContainer> sut = std::make_unique<TestContainer> ( wrapper );

    return sut;
}

TEST(Container, new_item_returns_new_item)
{
    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    Item_Ptr actual = sut->new_item();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Container, new_item_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    sut->new_item();

    // Assert
    EXPECT_EQ(expected, sut->get_length());
}

TEST(Container, get_length_returns_number_of_items)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();
    sut->new_item();

    // Act
    size_t actual = sut->get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Container, get_current_item_returns_current_item)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();

    // Act
    auto actual = sut->get_current_item();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Container, operator_index_returns_set_for_first_index)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    Item_Ptr item_one = sut->new_item();
    sut->new_item();

    // Act
    Item_Ptr actual = ( *sut.get() ) [ 0 ];

    // Assert
    EXPECT_EQ(item_one, actual);
}

TEST(Container, operator_index_returns_set_for_second_index)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();
    sut->new_item();
    Item_Ptr set_two = sut->new_item();

    // Act
    Item_Ptr actual = ( *sut.get() ) [ 1 ];

    // Assert
    EXPECT_EQ(set_two, actual);
}

TEST(Container, operator_index_throws_for_invalid_index_negative)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    // Assert
    EXPECT_THROW(
        (*sut.get())[-1],
        Tennis::Logic::ContainerException);
}

TEST(Container, operator_index_throws_for_invalid_index_to_big)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<TestContainer> sut = create_sut();

    // Act
    // Assert
    EXPECT_THROW(
        (*sut.get())[1000],
        Tennis::Logic::ContainerException);
}
