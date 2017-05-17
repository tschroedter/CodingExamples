#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
<<<<<<< HEAD
#include "SetFactory.h"
#include "Logger.h"
#include "Sets.h"

std::unique_ptr<Tennis::Logic::Sets> create_sut ()
{
    using namespace Tennis::Logic;

    std::unique_ptr<ILogger> logger = std::make_unique<Logger> ( std::cout );
    std::unique_ptr<GameFactory> game_factory = std::make_unique<GameFactory>();
    std::unique_ptr<TieBreakFactory> tie_break_factory = std::make_unique<TieBreakFactory> ( std::move ( logger ) );

    std::unique_ptr<SetFactory> factory = std::make_unique<SetFactory> (
                                                                        std::move ( game_factory ),

                                                                        std::move ( tie_break_factory ) );;

    std::unique_ptr<Sets> sut = std::make_unique<Sets> ( std::move ( factory ) );

    return sut;
}

TEST(Sets, new_sets_returns_new_set)
=======
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
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<Sets> sut = create_sut();

    // Act
    ISet* actual = sut->new_set();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Sets, new_set_adds_new_set)
=======
    Sets sut { wrapper };

    // Act
    ISet_Ptr actual = sut.create_new_set();

    // Assert
    EXPECT_NE(nullptr, actual);
}

TEST(Sets, create_new_set_adds_new_item)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
<<<<<<< HEAD
    std::unique_ptr<Sets> sut = create_sut();

    // Act
    sut->new_set();

    // Assert
    EXPECT_EQ(expected, sut->get_length());
}

TEST(Sets, get_length_returns_number_of_sets)
=======

    Sets sut { wrapper };

    // Act
    sut.create_new_set();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Sets, get_number_of_sets_returns_number_of_Sets)
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<Sets> sut = create_sut();
    sut->new_set();
    sut->new_set();

    // Act
    size_t actual = sut->get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Sets, get_current_set_returns_current_set)
=======
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
>>>>>>> Update from private repository
{
    using namespace Tennis::Logic;

    // Arrange
<<<<<<< HEAD
    std::unique_ptr<Sets> sut = create_sut();
    sut->new_set();

    // Act
    auto actual = sut->get_current_set();

    // Assert
    EXPECT_NE(nullptr, actual);
=======
    Sets sut { wrapper };
    ISet_Ptr expected = sut.create_new_set();

    auto first = sut.create_new_set();
    auto second = sut.create_new_set();

    // Act
    auto actual = sut.get_current_set();

    // Assert
    EXPECT_EQ(second, actual);
>>>>>>> Update from private repository
}
