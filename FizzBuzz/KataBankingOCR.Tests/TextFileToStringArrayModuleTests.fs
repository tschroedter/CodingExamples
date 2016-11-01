module TextFileToStringArrayModuleTests

open KataBankOCR.TextFileToStringArrayModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``readLinesFromFile returns ["123"] for file "0123456789.txt"`` () = 
    let line1 = " _     _  _     _  _  _  _  _ "
    let line2 = "| |  | _| _||_||_ |_   ||_||_|"
    let line3 = "|_|  ||_  _|  | _||_|  ||_|  |"
    let line4 = "                              "

    let expected = Array.ofList [line1;
                                 line2;
                                 line3;
                                 line4]

    let actual = readLinesFromFile "0123456789.txt"

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``fileToTextDigits returns ["123"] for file "0123456789.txt"`` () = 
    let expected =  [
                        "0123456789";
                        "0000000000"
                    ]
    let actual = fileToTextDigits "0123456789 and 0000000000.txt"

    Assert.AreEqual(expected, 
                    actual)
