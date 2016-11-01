namespace FizzBuzz

module Question =
    let Answer n =
        match n % 3, n % 5 with
        | 0,0 -> "FizzBuzz"
        | 0,_ -> "Fizz"
        | _,0 -> "Buzz"
        | _,_ -> string n

(*
    // If the value is divisible, then we return 'Some()' which
    // represents that the active pattern succeeds - the '()' notation
    // means that we don't return any value from the pattern (if we
    // returned for example 'Some(i/divisor)' the use would be:
    //     match 6 with 
    //     | DivisibleBy 3 res -> .. (res would be asigned value 2)
    // None means that pattern failed and that the next clause should 
    // be tried (by the match expression)
    let (|DivisibleBy|_|) divisor i = 
        if i % divisor = 0 then Some () else None 

    // & allows us to run more than one pattern on the argument 'i'
    // so this calls 'DivisibleBy 3 i' and 'DivisibleBy 5 i' and it
    // succeeds (and runs the body) only if both of them return 'Some()'
    let AnswerFor number =
        match number with
        | DivisibleBy 3 & DivisibleBy 5 -> printfn "FizzBuzz"
        | DivisibleBy 3 -> printfn "Fizz" 
        | DivisibleBy 5 -> printfn "Buzz" 
        | _ -> printfn "%d" number
*)