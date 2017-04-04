#pragma once
#include <string>

class Calculator
{
private:
   std::string m_result;

   static void replaceTextWithOtherText(
      std::string &text,
      const std::string &search,
      const std::string &replace)
   {
      int index = text.find(search);
      if (index != std::string::npos)
      {
         text = text.substr(0, text.length() - search.length());
         text += replace;
      }
   }

   static void replaceIIIIWithIV(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "IIII",
         "IV");
   }

   static void replaceXXXXWithXC(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "XXXX",
         "XC");
   }

   static void replaceCCCCWithCM(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "CCCC",
         "CM");
   }

   static void replaceVVWithX(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "VV",
         "X");
   }

   static void replaceLLWithC(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "LL",
         "C");
   }

   static void replaceCCWithM(std::string &text)
   {
      replaceTextWithOtherText(
         text,
         "CC",
         "M");
   }

   static void replace(std::string &text)
   {
      replaceIIIIWithIV(text);
      replaceXXXXWithXC(text);
      replaceCCCCWithCM(text);
      replaceVVWithX(text);
      replaceLLWithC(text);
      replaceCCWithM(text);
   }

public:
   Calculator()
   {
      m_result = "";
   }

   void enter(std::string romanNumber)
   {
      replace(romanNumber);

      m_result += romanNumber; // todo swap numbers see addReturnsVIForEnterIandV

      replace(m_result);
   }

   std::string add() const
   {
      return m_result;
   }
};
