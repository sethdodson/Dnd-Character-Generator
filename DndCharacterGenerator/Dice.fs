module Dice

open System

let random = new Random(DateTime.Now.Millisecond)

let roll dice sides = 
    Seq.initInfinite(fun index -> random.Next(1, (sides + 1)))
    |> Seq.take(dice)
    |> Seq.sum