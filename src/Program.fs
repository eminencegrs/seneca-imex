open System
open System.Linq
open Arguments
open Performer

[<EntryPoint>]
let main argv =
    let fileName =
        match (getFileName argv).SingleOrDefault() with
        | x when x <> null -> x
        | x when x = null -> invalidArg "filename" "Could not recognize filename."
        | _ -> invalidArg "arguments" "Could not recognize filename."

    let operation =
        match (getOperation argv).SingleOrDefault() with
        | x when x <> null -> x
        | x when x = null -> invalidArg "task" "Could not recognize task type."
        | _ -> invalidArg "arguments" "Could not recognize task type."

    let target =
        match (getTarget argv).SingleOrDefault() with
        | "machine" -> EnvironmentVariableTarget.Machine
        | "user" -> EnvironmentVariableTarget.User
        | _ -> invalidArg "arguments" "Could not recognize target type."

    performOperation operation fileName target

    0
