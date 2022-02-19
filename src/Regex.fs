module Seneca.Imex.Regex

open System.Text.RegularExpressions
open Seneca.Imex.Parameter
open Seneca.Imex.Operation

let getRegexOptions () = RegexOptions.Compiled ||| RegexOptions.IgnoreCase ||| RegexOptions.CultureInvariant;

let getTaskPattern () =
    $"(--{(getParameter Parameter.Task)}=(?<{(getParameter Parameter.Task)}>({(getOperation Operation.Export)})|({(getOperation Operation.Import)})))"

let getRegexForTask () = new Regex(getTaskPattern(), getRegexOptions())

let getTargetPattern () = $"(--{(getParameter Parameter.Target)}=(?<{(getParameter Parameter.Target)}>.+))"

let getRegexForTarget () = new Regex(getTargetPattern(), getRegexOptions())

let getFileNamePattern () = $"(--{(getParameter Parameter.FileName)}=(?<{(getParameter Parameter.FileName)}>.+))"

let getRegexForFileName () = new Regex(getFileNamePattern(), getRegexOptions())
