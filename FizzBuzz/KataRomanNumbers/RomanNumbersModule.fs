namespace RomanNumbers

module RomanNumbersModule = 
    let one = (1, ['I'])
    let four = (4, ['I';'V'])
    let five = (5, ['V'])
    let nine = (9, ['I';'X'])
    let ten = (10, ['X'])
    let fourty = (40, ['X';'L'])
    let fifty = (50, ['L'])
    let ninety = (90, ['X';'C'])
    let oneHundred = (100, ['C'])
    let fourHundred = (400, ['C';'D'])
    let fiveHundred = (500, ['D'])
    let nineHundred = (900, ['C';'M'])
    let oneThousand = (1000, ['M'])
    let all = [
                oneThousand,
                nineHundred,
                fiveHundred,
                fourHundred,
                oneHundred,
                ninety,
                fifty,
                fourty,
                ten,
                nine,
                five,
                four,
                one
              ]
    // todo list of numbers and apply

    let createArguments number romanNumbers romanNumber =
            let newNumber = number - fst romanNumber
            let newRomanNumber = List.append romanNumbers 
                                             (snd romanNumber)

            (newNumber, newRomanNumber)

    let rec toRomanNumber number romanNumbers =
        if number >= fst oneThousand then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               oneThousand

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst nineHundred then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               nineHundred

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst fiveHundred then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               fiveHundred

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst fourHundred then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               fourHundred

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst oneHundred then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               oneHundred

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst ninety then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               ninety

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst fifty then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               fifty

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst fourty then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               fourty

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst ten then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               ten

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst nine then
            let newArguments = createArguments number 
                                               romanNumbers 
                                               nine

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst five then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               five

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst four then
            let newArguments = createArguments number 
                                               romanNumbers 
                                               four

            toRomanNumber (fst newArguments)
                          (snd newArguments)

        elif number >= fst one then 
            let newArguments = createArguments number 
                                               romanNumbers 
                                               one

            toRomanNumber (fst newArguments)
                          (snd newArguments)


        else
            romanNumbers
         