module LineToDigitLineModuleTests

open KataBankOCR.TextDigitModule
open KataBankOCR.LinesToTextDigitsModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``chop returns ["123"] for string "123"`` () = 
    let expected = ["123"]
    let actual = chop "123"  3

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``chop returns ["123", "456"] for string "123456"`` () = 
    let expected = ["123";
                    "456"]
    let actual = chop "123456"  3

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``lineToDigitLine returns ["   "] for line "   "`` () = 
    let expected = ["   "]
    let actual = lineToDigitLine "   "

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``lineToDigitLine returns ["   ", " _ "] for line "    _ "`` () = 
    let expected = ["   ";
                    " _ "]
    let actual = lineToDigitLine "    _ "

    Assert.AreEqual(expected, 
                    actual)


[<Test>]
let ``digitLinesToTextDigits returns text digit zero for line zero`` () = 
    let line1 = [" _ "]
    let line2 = ["| |"]
    let line3 = ["|_|"]

    let expected = [textDigitZero]
    let actual = digitLinesToTextDigits line1 
                                        line2 
                                        line3

    Assert.AreEqual(expected.Length, 
                    actual.Length)

[<Test>]
let ``digitLinesToTextDigits returns text digit zero lines for line zero`` () = 
    let line1 = [" _ "]
    let line2 = ["| |"]
    let line3 = ["|_|"]

    let expected = textDigitZero
    let actual = (digitLinesToTextDigits line1 
                                        line2 
                                        line3).Head

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``digitLinesToTextDigits returns text digit zero and one for line zero one`` () = 
    let line1 = [" _    "]
    let line2 = ["| |  |"]
    let line3 = ["|_|  |"]

    let expected = [textDigitZero,textDigitOne]
    let actual = digitLinesToTextDigits line1 
                                        line2 
                                        line3

    Assert.AreEqual(expected.Length, 
                    actual.Length)

[<Test>]
let ``digitLinesToTextDigits returns text digit zero for line zero one`` () = 
    let line1 = [" _ ";"   "]
    let line2 = ["| |";"  |"]
    let line3 = ["|_|";"  |"]

    let expected = textDigitZero
    let actual = (digitLinesToTextDigits line1 
                                         line2 
                                         line3).Head

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``digitLinesToTextDigits returns text digit one for line zero one`` () = 
    let line1 = [" _ ";"   "]
    let line2 = ["| |";"  |"]
    let line3 = ["|_|";"  |"]

    let expected = textDigitOne
    let actual = (digitLinesToTextDigits line1 
                                         line2 
                                         line3).Tail.Head

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``linesToDigitLines returns text digits for line zero one`` () = 
    let line1 = " _     _  _     _  _  _  _  _ "
    let line2 = "| |  | _| _||_||_ |_   ||_||_|"
    let line3 = "|_|  ||_  _|  | _||_|  ||_|  |"

    let expected =  [
                        textDigitZero; 
                        textDigitOne; 
                        textDigitTwo;
                        textDigitThree;
                        textDigitFour;
                        textDigitFive;
                        textDigitSix;
                        textDigitSeven;
                        textDigitEight;
                        textDigitNine
                    ]

    let actual = linesToTextDigits line1 
                                   line2 
                                   line3

    Assert.AreEqual(expected, 
                    actual)