// Learn more about F# at http://fsharp.net

#light

open System
    
[<EntryPoint>]
let main args =
    printfn "Arguments passed to function : %A" args
    Console.ReadLine() |> ignore
    // Return 0. This indicates success.
    0