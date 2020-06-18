module Performer

open System
open System.IO
open System.Runtime.Serialization.Json
open System.Collections
open Extensions

let performOperation (operation : string) (fileName : string) (target : EnvironmentVariableTarget) =
    match operation with
    | "import" ->
        use stream = new FileStream(fileName, FileMode.Open)
        let object = (new DataContractJsonSerializer(typeof<Hashtable>)).ReadObject(stream)
        let variables = objectToHashtable object
        variables
        |> Seq.cast<DictionaryEntry>
        |> Seq.iter (fun entry -> System.Environment.SetEnvironmentVariable(entry.Key.ToString(), entry.Value.ToString(), target))
    | "export" ->
        let variables = System.Environment.GetEnvironmentVariables(target)
        use stream = new FileStream(fileName, FileMode.Create)
        (new DataContractJsonSerializer(typeof<Hashtable>)).WriteObject(stream, variables)
    | _ -> invalidOp "Could not recognize operation type."
