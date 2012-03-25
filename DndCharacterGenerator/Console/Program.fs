// Learn more about F# at http://fsharp.net

open CharacterGenerator
open System

Console.WriteLine("Character Generator")

let generateCharacters = 
    let mutable level = "z"
    while 