// Learn more about F# at http://fsharp.net

#light

module Cards

let denominators = [ 1..10 ]

let product input = List.map(fun x -> x * input) 

let numerators = denominators |> List.map(fun d -> product d denominators) |> List.concat

type FlashCard =
    { Numerator: int;
      Denominator: int;
      Answer: int; }
    static member GetFlashCard = function
        | (n, d, a) -> { Numerator = n; Denominator = d; Answer = a }

let flashCards = 
    let answerOk = function
        | (n, d, a) -> List.exists(fun d -> d = a) denominators
    let numeratorCards numerator = 
        denominators
        |> List.filter(fun d -> (numerator % d) = 0) 
        |> List.map(fun d -> (numerator, d, (numerator / d)))
    numerators 
    |> List.map(numeratorCards) 
    |> List.concat
    |> List.filter(answerOk)

let numberOfCards = List.length flashCards

open System

let random = new Random(DateTime.Now.Millisecond)

let numberOfProblems = 30

let problemCards = 
    Seq.initInfinite(fun index -> random.Next(0, numberOfCards))
    |> Seq.take(numberOfProblems)
    |> Seq.toList
    |> List.map(fun p -> List.nth flashCards p)
    |> List.map(FlashCard.GetFlashCard)