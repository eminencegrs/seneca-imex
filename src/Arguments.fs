module Arguments

open System.Collections.Generic
open System.Text.RegularExpressions

let getRegex () =
    new Regex(@"(--task=(?<task>(export)|(import)))|(--target=(?<target>.+))|(--filename=(?<filename>.+))", RegexOptions.IgnoreCase)

let getFileName arguments : string[] =
    arguments |> Array.choose (fun arg ->
        let argument = getRegex().Match(arg)
        match argument.Success with
            | true -> 
                let value = argument.Groups.GetValueOrDefault("filename").Value
                match value with
                | x when x <> "" -> Some(x)
                | _ -> None
            | false -> invalidArg "arguments" "Could not parse arguments properly")

let getOperation arguments : string[] =
    arguments |> Array.choose (fun arg ->
        let argument = getRegex().Match(arg)
        match argument.Success with
            | true -> 
                let operation = argument.Groups.GetValueOrDefault("task").Value
                match operation with
                | "export"
                | "import" -> Some operation
                | _ -> None
            | false -> invalidArg "arguments" "Could not parse arguments properly")

let getTarget arguments : string[] =
    arguments |> Array.choose (fun arg ->
        let argument = getRegex().Match(arg)
        match argument.Success with
            | true -> 
                let target = argument.Groups.GetValueOrDefault("target").Value
                match target with
                | "machine"
                | "user" -> Some target
                | _ -> None
            | false -> invalidArg "arguments" "Could not parse arguments properly")
