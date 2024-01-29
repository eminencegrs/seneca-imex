namespace Seneca.Imex

open System
open System.Collections.Generic
open Operations
open Parameters
open Regex

module ParametersHandler =

    let getFileName (parameters : string[]) : string =
        let parameter = Seq.tryFind (fun arg -> getRegexForFileName().IsMatch(arg)) parameters
        match parameter with
        | x when x.IsSome ->
             getRegexForFileName()
                .Match(parameter.Value)
                .Groups.GetValueOrDefault(getParameter ParameterType.FileName)
                .Value.ToLowerInvariant()
        | _ -> invalidArg "--filename" "The '--filename' parameter must not be null or empty"

    let getOperation (parameters : string[]) : OperationType =
        let parameter = Seq.tryFind (fun arg -> getRegexForTask().IsMatch(arg)) parameters
        match parameter with
        | x when x.IsSome ->
            let task =
                getRegexForTask()
                    .Match(parameter.Value)
                    .Groups.GetValueOrDefault(getParameter ParameterType.Task)
                    .Value.ToLowerInvariant()
            match task with
            | "export" -> OperationType.Export
            | "import" -> OperationType.Import
            | _ -> invalidArg "--task" "Could not recognize a task"
        | _ -> invalidArg "--task" "The '--task' parameter must not be null or empty"

    let getTarget (parameters : string[]) : EnvironmentVariableTarget =
        let parameter = Seq.tryFind (fun arg -> getRegexForTarget().IsMatch(arg)) parameters
        match parameter with
        | x when x.IsSome ->
            let target =
                getRegexForTarget()
                    .Match(parameter.Value)
                    .Groups.GetValueOrDefault(getParameter ParameterType.Target)
                    .Value.ToLowerInvariant()
            match target with
            | "machine" -> EnvironmentVariableTarget.Machine
            | "user" -> EnvironmentVariableTarget.User
            | _ -> invalidArg "--target" "Could not recognize a target"
        | _ -> invalidArg "--target" "The '--target' parameter must not be null or empty"
