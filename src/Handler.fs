module Handler

open System
open System.Collections
open System.IO
open System.Runtime.Serialization.Json
open Extensions
open Operation

let export (fileName : string) (target : EnvironmentVariableTarget) =
    try
        let variables = System.Environment.GetEnvironmentVariables(target)
        use stream = new FileStream(fileName, FileMode.Create)
        (new DataContractJsonSerializer(typeof<Hashtable>)).WriteObject(stream, variables)
    with
        | ex -> invalidOp $"Could not export environment variables. Inner error: {ex.Message}"

let import (fileName : string) (target : EnvironmentVariableTarget) =
    try
        use stream = new FileStream(fileName, FileMode.Open)
        let object = (new DataContractJsonSerializer(typeof<Hashtable>)).ReadObject(stream)
        objectToHashtable object
        |> Seq.cast<DictionaryEntry>
        |> Seq.iter (fun entry -> System.Environment.SetEnvironmentVariable(entry.Key.ToString(), entry.Value.ToString(), target))
    with
        | ex -> invalidOp $"Could not import environment variables. Inner error: {ex.Message}"

let handle (operation : OperationName) (fileName : string) (target : EnvironmentVariableTarget) =
    match operation with
    | OperationName.Export -> export fileName target
    | OperationName.Import -> import fileName target
