// RomanNumerals.Tests.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include "gtest/gtest.h"
#include "Converter.h"

TEST(romanNumerals, convertReturnsEmptyStringFor0)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(0);

   // Assert
   EXPECT_EQ("", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor1)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(1);

   // Assert
   EXPECT_EQ("I", actual);
}


TEST(romanNumerals, convertReturnsEmptyStringFor2)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(2);

   // Assert
   EXPECT_EQ("II", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor3)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(3);

   // Assert
   EXPECT_EQ("III", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor4)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(4);

   // Assert
   EXPECT_EQ("IV", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor5)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(5);

   // Assert
   EXPECT_EQ("V", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor6)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(6);

   // Assert
   EXPECT_EQ("VI", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor7)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(7);

   // Assert
   EXPECT_EQ("VII", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor8)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(8);

   // Assert
   EXPECT_EQ("VIII", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor9)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(9);

   // Assert
   EXPECT_EQ("IX", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor10)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(10);

   // Assert
   EXPECT_EQ("X", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor49)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(49);

   // Assert
   EXPECT_EQ("IL", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor50)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(50);

   // Assert
   EXPECT_EQ("L", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor99)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(99);

   // Assert
   EXPECT_EQ("IC", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor100)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(100);

   // Assert
   EXPECT_EQ("C", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor499)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(499);

   // Assert
   EXPECT_EQ("ID", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor500)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(500);

   // Assert
   EXPECT_EQ("D", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor999)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(999);

   // Assert
   EXPECT_EQ("IM", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor1000)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(1000);

   // Assert
   EXPECT_EQ("M", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor1990)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(1990);

   // Assert
   EXPECT_EQ("MCMXC", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor2008)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(2008);

   // Assert
   EXPECT_EQ("MMVIII", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor1904)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(1904);

   // Assert
   EXPECT_EQ("MCMIV", actual);
}

TEST(romanNumerals, convertReturnsEmptyStringFor1954)
{
   // Arrange
   Converter sut;

   // Act
   std::string actual = sut.convert(1954);

   // Assert
   EXPECT_EQ("MCMLIV", actual);
}
