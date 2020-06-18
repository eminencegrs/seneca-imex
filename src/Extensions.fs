module Extensions

open System
open System.Collections

let objectToHashtable (obj : Object) =
   match obj with
   | :? Hashtable as hashtable -> hashtable
   | _ -> invalidOp "Could not cast the object read from the file to Hashtable"
