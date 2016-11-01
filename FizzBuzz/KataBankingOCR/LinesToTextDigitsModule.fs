namespace KataBankOCR

module LinesToTextDigitsModule =

    open KataBankOCR.TextDigitModule

    let numberOfCharactersPerDigit = 3

    let chop (input : string) len = 
        Array.init (input.Length / len) (fun index ->
            let start = index * len
            input.[start..start + len - 1])
            |> List.ofArray

    let lineToDigitLine (line:string) : list<string> =
        chop line numberOfCharactersPerDigit

    let rec digitLinesToTextDigits (digitLine1 : list<string>)
                                   (digitLine2 : list<string>)
                                   (digitLine3 : list<string>) : list<TextDigit> =

        if List.isEmpty digitLine1 then 
            []
        else
            let headLine1 = List.head digitLine1
            let headLine2 = List.head digitLine2
            let headLine3 = List.head digitLine3

            let headTextDigit : TextDigit = { 
                                                Line1 = headLine1;
                                                Line2 = headLine2;
                                                Line3 = headLine3 
                                            }

            let tailLine1 = List.tail digitLine1
            let tailLine2 = List.tail digitLine2
            let tailLine3 = List.tail digitLine3

            let tailTextDigits = digitLinesToTextDigits tailLine1
                                                        tailLine2
                                                        tailLine3

            List.append [headTextDigit] tailTextDigits

    let linesToTextDigits (line1:string)
                          (line2:string)
                          (line3:string) =

        let digitLine1 = lineToDigitLine line1
        let digitLine2 = lineToDigitLine line2
        let digitLine3 = lineToDigitLine line3

        let textDigits = digitLinesToTextDigits digitLine1 
                                                digitLine2 
                                                digitLine3

        textDigits