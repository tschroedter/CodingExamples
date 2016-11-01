namespace KataBankOCR

module TextFileToStringArrayModule =

    open System.IO
    open KataBankOCR.LinesToTextDigitsModule
    open KataBankOCR.TextDigitsToIntegersModule

    let readLinesFromFile (filePath:string) =
        try
            File.ReadAllLines(filePath)
        with 
            | :? System.IO.FileNotFoundException as ex -> Array.ofList [ex.Message]


    let rec skip n xs =  // todo testing
        match (n, xs) with
        | 0, _ -> xs
        | _, [] -> []
        | n, _::xs -> skip (n-1) xs

    let skipForArray n xs = // todo testing, should be recursive like skip???
        let list = List.ofArray xs
        let skipped = skip n list
        Array.ofList skipped


    let stringArrayToTextDigits (lines : string[]) =
        linesToTextDigits (Array.get lines 0)
                          (Array.get lines 1)
                          (Array.get lines 2)

    let rec lineByLine (lines : string[]) =

        match lines.Length with
        | 0 ->  []
        | _ ->  let textDigits = stringArrayToTextDigits lines
                let accountNumber = textDigitsToString textDigits
                let nextAccountNumbers = skipForArray 4 lines
                let otherAccountNumbers = lineByLine nextAccountNumbers

                List.append [accountNumber] otherAccountNumbers

    let fileToTextDigits (filePath:string) =
        let lines = readLinesFromFile filePath
        let accountNumbers = []

        lineByLine lines
    