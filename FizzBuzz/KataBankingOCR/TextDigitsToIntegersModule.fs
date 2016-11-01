namespace KataBankOCR

module TextDigitsToIntegersModule = 

    open KataBankOCR.TextDigitModule
    open KataBankOCR.TextDigitToIntegerModule

    let rec convertToString list =
       match list with
       | [l] -> l.ToString()
       | head :: tail -> head.ToString() + convertToString tail
       | [] -> ""

    let textDigitsToIntegers (textDigits : list<TextDigit>)  =
        textDigits |> List.map textDigitToInteger

    let textDigitsToString (textDigits : list<TextDigit>) = 
        textDigits 
        |> List.map textDigitToInteger |> convertToString