﻿namespace Seneca.Imex

open System
open System.Collections

module Extensions =

    let objectToHashtable (obj : Object) =
       match obj with
       | :? Hashtable as hashtable -> hashtable
       | _ -> invalidOp "Could not cast the object (read from the file) to Hashtable"
