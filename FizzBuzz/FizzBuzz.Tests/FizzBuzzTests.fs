namespace FizzBuzz.Tests.Hello

open FizzBuzz.Question
open NUnit.Framework
open FsUnit

[<TestFixture>]
type ``Given the AnswerFor function``()=

    [<TestCase(1,"1")>]
    [<TestCase(2,"2")>]
    [<TestCase(3,"Fizz")>]
    [<TestCase(4,"4")>]
    [<TestCase(5,"Buzz")>]
    [<TestCase(6,"Fizz")>]
    [<TestCase(5,"Buzz")>]
    [<TestCase(7,"7")>]
    [<TestCase(8,"8")>]
    [<TestCase(9,"Fizz")>]
    [<TestCase(10,"Buzz")>]
    [<TestCase(11,"11")>]
    [<TestCase(12,"Fizz")>]
    [<TestCase(13,"13")>]
    [<TestCase(14,"14")>]
    [<TestCase(15,"FizzBuzz")>]
    member t.``the result is calculated correctly``(n, expected) = 
        let actual = Answer n 
        actual |> should equal expected