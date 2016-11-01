module TextDigitsToIntegersModuleTests

open KataBankOCR.TextDigitModule
open KataBankOCR.TextDigitsToIntegersModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``textDigitsToIntegers returns [0] for digits [zero]`` () = 
    let textDigits = [textDigitZero]
    let expected = [0]
    let actual = textDigitsToIntegers textDigits

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitsToIntegers returns [0,1,2,3,4,5,6,7,8,9] for digits [zero, one, two, three, four, five, six, seven, eight, nine]`` () = 
    let textDigits = [
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
    let expected = [0;1;2;3;4;5;6;7;8;9]
    let actual = textDigitsToIntegers textDigits

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitsToString returns "0" for digits [zero]`` () = 
    let textDigits = [textDigitZero]
    let expected = "0"
    let actual = textDigitsToString textDigits

    Assert.AreEqual(expected, 
                    actual)

[<Test>]
let ``textDigitsToString returns "0123456789" for digits [zero, one, two, three, four, five, six, seven, eight, nine]`` () = 
    let textDigits = [
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
    let expected = "0123456789"
    let actual = textDigitsToString textDigits

    Assert.AreEqual(expected, 
                    actual)
