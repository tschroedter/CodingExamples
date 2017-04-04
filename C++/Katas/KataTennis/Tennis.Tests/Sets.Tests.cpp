#include "stdafx.h"
#include <gtest/gtest.h>
#include <memory>
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
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Sets> sut = create_sut();

    // Act
    ISet* actual = sut->new_set();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Sets, new_set_adds_new_set)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<Sets> sut = create_sut();

    // Act
    sut->new_set();

    // Assert
    EXPECT_EQ(expected, sut->get_length());
}

TEST(Sets, get_length_returns_number_of_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Sets> sut = create_sut();
    sut->new_set();
    sut->new_set();

    // Act
    size_t actual = sut->get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Sets, get_current_set_returns_current_set)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<Sets> sut = create_sut();
    sut->new_set();

    // Act
    auto actual = sut->get_current_set();

    // Assert
    EXPECT_NE(nullptr, actual);
}
