#pragma once

#include <string>

struct RomanNumber
{
   std::string text;
   int value;
};

class RomanNumbers
{
private:
   static const size_t m_size = 17;
   const RomanNumber m_numbers[m_size] = 
   {
      RomanNumber{ "M", 1000 },
      RomanNumber{ "IM", 999 },
      RomanNumber{ "CM", 900 },
      RomanNumber{ "D", 500 },
      RomanNumber{ "ID", 499 },
      RomanNumber{ "CD", 400 },
      RomanNumber{ "C", 100 },
      RomanNumber{ "IC", 99 },
      RomanNumber{ "XC", 90 },
      RomanNumber{ "L", 50 },
      RomanNumber{ "IL", 49 },
      RomanNumber{ "XL", 40 },
      RomanNumber{ "X", 10 },
      RomanNumber{ "IX", 9 },
      RomanNumber{ "V", 5 },
      RomanNumber{ "IV", 4 },
      RomanNumber{ "I", 1 }
   };

public:
   RomanNumbers() {}

   const RomanNumber& RomanNumbers::operator[] (const int index)
   {
      return m_numbers[index];
   }

   const RomanNumber& RomanNumbers::operator[] (const int index) const
   {
      return m_numbers[index];
   }

   static size_t getSize()
   {
      return m_size;
   }
};
