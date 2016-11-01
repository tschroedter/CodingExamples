namespace KataBankOCR

module TextDigitToIntegerModule =

    open KataBankOCR.TextDigitModule
    open KataBankOCR.IsTextDigitModule

// todo use list
(*
    let isTextDigitList =
        [
            isZeroTextDigit,
            isOneTextDigit,
            isTwoTextDigit,
            isThreeTextDigit,
            isFourTextDigit,
            isFiveTextDigit,
            isSixTextDigit,
            isSevenTextDigit,
            isEightTextDigit,
            isNineTextDigit
        ]
*)

    let textDigitToInteger textDigit = 
        if isZeroTextDigit textDigit then 0
        elif isOneTextDigit textDigit then 1
        elif isTwoTextDigit textDigit then 2
        elif isThreeTextDigit textDigit then 3
        elif isFourTextDigit textDigit then 4
        elif isFiveTextDigit textDigit then 5
        elif isSixTextDigit textDigit then 6
        elif isSevenTextDigit textDigit then 7
        elif isEightTextDigit textDigit then 8
        elif isNineTextDigit textDigit then 9
        else -1 // todo maybe none