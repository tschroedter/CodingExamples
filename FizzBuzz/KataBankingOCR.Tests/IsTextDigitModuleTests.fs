module IsTextDigitModuleTests

open KataBankOCR.TextDigitModule
open KataBankOCR.IsTextDigitModule
open NUnit.Framework
open FsUnit

[<Test>]
let ``isZeroTextDigit returns true for digit is zero`` () = 
    let actual = isZeroTextDigit textDigitZero

    Assert.True(actual)

[<Test>]
let ``isZeroTextDigit returns false for digit is not zero`` () = 
    let actual = isZeroTextDigit textDigitOne

    Assert.False(actual)

[<Test>]
let ``isOneTextDigit returns true for digit is one`` () = 
    let actual = isOneTextDigit textDigitOne

    Assert.True(actual)

[<Test>]
let ``isOneTextDigit returns false for digit is not one`` () = 
    let actual = isOneTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isTwoTextDigit returns true for digit is two`` () = 
    let actual = isTwoTextDigit textDigitTwo

    Assert.True(actual)

[<Test>]
let ``isTwoTextDigit returns false for digit is not two`` () = 
    let actual = isTwoTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isThreeTextDigit returns true for digit is three`` () = 
    let actual = isThreeTextDigit textDigitThree

    Assert.True(actual)

[<Test>]
let ``isThreeTextDigit returns false for digit is not one`` () = 
    let actual = isThreeTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isFourTextDigit returns true for digit is four`` () = 
    let actual = isFourTextDigit textDigitFour

    Assert.True(actual)

[<Test>]
let ``isFourTextDigit returns false for digit is not four`` () = 
    let actual = isFourTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isFiveTextDigit returns true for digit is five`` () = 
    let actual = isFiveTextDigit textDigitFive

    Assert.True(actual)

[<Test>]
let ``isFiveTextDigit returns false for digit is not five`` () = 
    let actual = isFiveTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isSixTextDigit returns true for digit is six`` () = 
    let actual = isSixTextDigit textDigitSix

    Assert.True(actual)

[<Test>]
let ``isSixTextDigit returns false for digit is not six`` () = 
    let actual = isSixTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isSevenTextDigit returns true for digit is seven`` () = 
    let actual = isSevenTextDigit textDigitSeven

    Assert.True(actual)

[<Test>]
let ``isSevenTextDigit returns false for digit is not seven`` () = 
    let actual = isSevenTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isEightTextDigit returns true for digit is eight`` () = 
    let actual = isEightTextDigit textDigitEight

    Assert.True(actual)

[<Test>]
let ``isEightTextDigit returns false for digit is not eight`` () = 
    let actual = isEightTextDigit textDigitZero

    Assert.False(actual)

[<Test>]
let ``isNineTextDigit returns true for digit is nine`` () = 
    let actual = isNineTextDigit textDigitNine

    Assert.True(actual)

[<Test>]
let ``isNineTextDigit returns false for digit is not nine`` () = 
    let actual = isNineTextDigit textDigitZero

    Assert.False(actual)
