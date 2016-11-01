namespace KataBankOCR

module IsTextDigitModule = 

    open KataBankOCR.TextDigitModule

    let isTextDigit expectedDigit actualDigit =
        if  expectedDigit.Line1 = actualDigit.Line1 && 
            expectedDigit.Line2 = actualDigit.Line2 &&
            expectedDigit.Line3 = actualDigit.Line3 then 
            true
        else
            false

    let isZeroTextDigit digit =
        isTextDigit textDigitZero digit 

    let isOneTextDigit digit =
        isTextDigit textDigitOne digit 

    let isTwoTextDigit digit =
        isTextDigit textDigitTwo digit 

    let isThreeTextDigit digit =
        isTextDigit textDigitThree digit 

    let isFourTextDigit digit =
        isTextDigit textDigitFour digit 

    let isFiveTextDigit digit =
        isTextDigit textDigitFive digit 

    let isSixTextDigit digit =
        isTextDigit textDigitSix digit 

    let isSevenTextDigit digit =
        isTextDigit textDigitSeven digit 

    let isEightTextDigit digit =
        isTextDigit textDigitEight digit 

    let isNineTextDigit digit =
        isTextDigit textDigitNine digit 
