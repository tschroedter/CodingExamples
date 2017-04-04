// RomanCalculator.Tests.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <gtest/gtest.h>
#include "Calculator.h"


TEST(calculator, addReturnsIForEnterI)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("I");

   // Assert
   EXPECT_EQ("I", sut.add());
}

TEST(calculator, addReturnsIIForEnterIandI)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("I");
   sut.enter("I");

   // Assert
   EXPECT_EQ("II", sut.add());
}

TEST(calculator, addReturnsIIIForEnterIandIandI)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("I");
   sut.enter("I");
   sut.enter("I");

   // Assert
   EXPECT_EQ("III", sut.add());
}

TEST(calculator, addReturnsIVForEnterIandIandIandI)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("I");
   sut.enter("I");
   sut.enter("I");
   sut.enter("I");

   // Assert
   EXPECT_EQ("IV", sut.add());
}

TEST(calculator, addReturnsXForEnterX)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("X");

   // Assert
   EXPECT_EQ("X", sut.add());
}

TEST(calculator, addReturnsXXForEnterXandX)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("X");
   sut.enter("X");

   // Assert
   EXPECT_EQ("XX", sut.add());
}

TEST(calculator, addReturnsXXXForEnterXandXandX)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("X");
   sut.enter("X");
   sut.enter("X");

   // Assert
   EXPECT_EQ("XXX", sut.add());
}

TEST(calculator, addReturnsXCForEnterXandXandXandX)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("X");
   sut.enter("X");
   sut.enter("X");
   sut.enter("X");

   // Assert
   EXPECT_EQ("XC", sut.add());
}

TEST(calculator, addReturnsCForEnterC)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("C");

   // Assert
   EXPECT_EQ("C", sut.add());
}

TEST(calculator, addReturnsCCForEnterCandC)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("C");
   sut.enter("C");

   // Assert
   EXPECT_EQ("M", sut.add());
}

TEST(calculator, addReturnsCCCForEnterCandCandC)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("C");
   sut.enter("C");
   sut.enter("C");

   // Assert
   EXPECT_EQ("MC", sut.add());
}

TEST(calculator, addReturnsCMForEnterCandCandCandC)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("C");
   sut.enter("C");
   sut.enter("C");
   sut.enter("C");

   // Assert
   EXPECT_EQ("MM", sut.add());
}

TEST(calculator, addReturnsXForEnterVandV)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("V");
   sut.enter("V");

   // Assert
   EXPECT_EQ("X", sut.add());
}

TEST(calculator, addReturnsVIForEnterVandI)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("V");
   sut.enter("I");

   // Assert
   EXPECT_EQ("VI", sut.add());
}

TEST(calculator, addReturnsVIForEnterIandV)
{
   // Arrange
   Calculator sut;

   // Act
   sut.enter("I");
   sut.enter("V");

   // Assert
   EXPECT_EQ("VI", sut.add());
}
