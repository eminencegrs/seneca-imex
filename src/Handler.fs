module Handler

open System
open System.Collections
open System.IO
open System.Runtime.Serialization.Json
open Extensions
open Operation

let export (fileName : string) (target : EnvironmentVariableTarget) =
    let variables = System.Environment.GetEnvironmentVariables(target)
    use stream = new FileStream(fileName, FileMode.Create)
    (new DataContractJsonSerializer(typeof<Hashtable>)).WriteObject(stream, variables)

let import (fileName : string) (target : EnvironmentVariableTarget) =
    use stream = new FileStream(fileName, FileMode.OpenOrCreate)
    let object = (new DataContractJsonSerializer(typeof<Hashtable>)).ReadObject(stream)
    objectToHashtable object
    |> Seq.cast<DictionaryEntry>
    |> Seq.iter (fun entry -> System.Environment.SetEnvironmentVariable(entry.Key.ToString(), entry.Value.ToString(), target))

let handle (operation : OperationName) (fileName : string) (target : EnvironmentVariableTarget) =
    match operation with
    | OperationName.Export -> export fileName target
    | OperationName.Import -> import fileName target
    | _ -> invalidOp "Could not recognize the operation."
