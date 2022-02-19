module Seneca.Imex.ParametersHandler

open System
open System.Collections.Generic
open Seneca.Imex.Parameter
open Seneca.Imex.Regex
open Seneca.Imex.Operation

let getFileName (parameters : string[]) : string =
    let parameter = Seq.tryFind (fun arg -> getRegexForFileName().IsMatch(arg)) parameters
    match parameter with
    | x when x.IsSome -> getRegexForFileName().Match(parameter.Value).Groups.GetValueOrDefault(getParameter Parameter.FileName).Value.ToLowerInvariant()
    | _ -> invalidArg "--filename" "The '--filename' parameter must not be null or empty"

let getOperation (parameters : string[]) : Operation =
    let parameter = Seq.tryFind (fun arg -> getRegexForTask().IsMatch(arg)) parameters
    match parameter with
    | x when x.IsSome ->
        let task = getRegexForTask().Match(parameter.Value).Groups.GetValueOrDefault(getParameter Parameter.Task).Value.ToLowerInvariant()
        match task with
        | "export" -> Operation.Export
        | "import" -> Operation.Import
        | _ -> invalidArg "--task" "Could not recognize a task"
    | _ -> invalidArg "--task" "The '--task' parameter must not be null or empty"

let getTarget (parameters : string[]) : EnvironmentVariableTarget =
    let parameter = Seq.tryFind (fun arg -> getRegexForTarget().IsMatch(arg)) parameters
    match parameter with
    | x when x.IsSome ->
        let target = getRegexForTarget().Match(parameter.Value).Groups.GetValueOrDefault(getParameter Parameter.Target).Value.ToLowerInvariant()
        match target with
        | "machine" -> EnvironmentVariableTarget.Machine
        | "user" -> EnvironmentVariableTarget.User
        | _ -> invalidArg "--target" "Could not recognize a target"
    | _ -> invalidArg "--target" "The '--target' parameter must not be null or empty"
