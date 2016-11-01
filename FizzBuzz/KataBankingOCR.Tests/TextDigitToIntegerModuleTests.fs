module TextDigitToIntegerModuleTests

open KataBankOCR.TextDigitModule
open KataBankOCR.IsTextDigitModule
open KataBankOCR.TextDigitToIntegerModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``textDigitToInteger returns 0 for digit is zero`` () = 
    let expected = 0
    let actual = textDigitToInteger textDigitZero

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is one`` () = 
    let expected = 1
    let actual = textDigitToInteger textDigitOne

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is two`` () = 
    let expected = 2
    let actual = textDigitToInteger textDigitTwo

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is three`` () = 
    let expected = 3
    let actual = textDigitToInteger textDigitThree

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is four`` () = 
    let expected = 4
    let actual = textDigitToInteger textDigitFour

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is five`` () = 
    let expected = 5
    let actual = textDigitToInteger textDigitFive

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is six`` () = 
    let expected = 6
    let actual = textDigitToInteger textDigitSix

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is seven`` () = 
    let expected = 7
    let actual = textDigitToInteger textDigitSeven

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is eight`` () = 
    let expected = 8
    let actual = textDigitToInteger textDigitEight

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns 1 for digit is nine`` () = 
    let expected = 9
    let actual = textDigitToInteger textDigitNine

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitToInteger returns -1 for digit is unknown`` () = 
    let textDigitUnknown  =    
        {
            Line1 = "___";
            Line2 = "___";
            Line3 = "___"
        }

    let expected = -1
    let actual = textDigitToInteger textDigitUnknown

    Assert.AreEqual(expected, 
                    actual)
