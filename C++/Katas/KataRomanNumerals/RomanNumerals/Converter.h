#pragma once

#include <string>
#include "RomanNumbers.h"
#include <iostream>

class Converter
{
private:
   RomanNumbers m_roman_numbers{};

public:
   Converter() {}
   
   std::string Converter::convert(int number) const
   {
      std::string result = "";

      int currentNumber = number;

      for (size_t i = 0; i<m_roman_numbers.getSize(); i++)
      {
         RomanNumber current = m_roman_numbers[i];

         int value = current.value;

         while (currentNumber >= value)
         {
            result += current.text;
            currentNumber -= value;
         }
      }

      return result;
   }
};

