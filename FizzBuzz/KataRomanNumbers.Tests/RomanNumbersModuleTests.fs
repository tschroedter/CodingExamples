module LineToDigitLineModuleTests

open RomanNumbers.RomanNumbersModule
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``Given the toRomanNumber function``()=

    let explode (s:string) =
        [for c in s -> c]

    [<TestCase(1, "I")>]
    [<TestCase(2, "II")>]
    [<TestCase(3, "III")>]
    [<TestCase(4, "IV")>]
    [<TestCase(5, "V")>]
    [<TestCase(6, "VI")>]
    [<TestCase(7, "VII")>]
    [<TestCase(8, "VIII")>]
    [<TestCase(9, "IX")>]
    [<TestCase(10, "X")>]
    [<TestCase(11, "XI")>]
    [<TestCase(12, "XII")>]
    [<TestCase(13, "XIII")>]
    [<TestCase(49, "XLIX")>]
    [<TestCase(99, "XCIX")>]
    [<TestCase(100, "C")>]
    [<TestCase(101, "CI")>]
    [<TestCase(499, "CDXCIX")>]
    [<TestCase(500, "D")>]
    [<TestCase(501, "DI")>]
    [<TestCase(999, "CMXCIX")>]
    [<TestCase(1000, "M")>]
    [<TestCase(1001, "MI")>]
    [<TestCase(1999, "MCMXCIX")>]
    [<TestCase(1990, "MCMXC")>]
    [<TestCase(2008, "MMVIII")>]
    [<TestCase(1904, "MCMIV")>]
    [<TestCase(1954, "MCMLIV")>]
    [<TestCase(2014, "MMXIV")>]
    member t.``the result is calculated correctly``(n, text) = 
        let expected = explode text
        let actual = toRomanNumber n [] 
        actual |> should equal expected

