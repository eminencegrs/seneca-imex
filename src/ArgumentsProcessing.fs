module ArgumentsProcessing

open System
open System.Collections.Generic
open Argument
open Regex
open Operation

let getFileName (arguments : string[]) : string =
    let argument = Seq.tryFind (fun arg -> getRegexForFileName().IsMatch(arg)) arguments
    match argument with
    | x when x.IsSome -> getRegexForFileName().Match(argument.Value).Groups.GetValueOrDefault(getArgumentValue ArgumentName.FileName).Value.ToLowerInvariant()
    | _ -> invalidArg "--filename" "The '--filename' parameter must not be null or empty"

let getOperation (arguments : string[]) : OperationName =
    let argument = Seq.tryFind (fun arg -> getRegexForTask().IsMatch(arg)) arguments
    match argument with
    | x when x.IsSome ->
        let task = getRegexForTask().Match(argument.Value).Groups.GetValueOrDefault(getArgumentValue ArgumentName.Task).Value.ToLowerInvariant()
        match task with
        | "export" -> OperationName.Export
        | "import" -> OperationName.Import
        | _ -> invalidArg "--task" "Could not recognize a task"
    | _ -> invalidArg "--task" "The '--task' parameter must not be null or empty"

let getTarget (arguments : string[]) : EnvironmentVariableTarget =
    let argument = Seq.tryFind (fun arg -> getRegexForTarget().IsMatch(arg)) arguments
    match argument with
    | x when x.IsSome ->
        let target = getRegexForTarget().Match(argument.Value).Groups.GetValueOrDefault(getArgumentValue ArgumentName.Target).Value.ToLowerInvariant()
        match target with
        | "machine" -> EnvironmentVariableTarget.Machine
        | "user" -> EnvironmentVariableTarget.User
        | _ -> invalidArg "--target" "Could not recognize a target"
    | _ -> invalidArg "--target" "The '--target' parameter must not be null or empty"
