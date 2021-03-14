module Regex

open System.Text.RegularExpressions
open Argument
open Operation

let getRegexOptions () =
    RegexOptions.Compiled ||| RegexOptions.IgnoreCase ||| RegexOptions.CultureInvariant;

let getTaskPattern () =
    $"(--{(getArgumentValue ArgumentName.Task)}=(?<{(getArgumentValue ArgumentName.Task)}>({(getOperationValue OperationName.Export)})|({(getOperationValue OperationName.Import)})))"

let getRegexForTask () =
    new Regex(getTaskPattern(), getRegexOptions())

let getTargetPattern () =
    $"(--{(getArgumentValue ArgumentName.Target)}=(?<{(getArgumentValue ArgumentName.Target)}>.+))"

let getRegexForTarget () =
    new Regex(getTargetPattern(), getRegexOptions())

let getFileNamePattern () =
    $"(--{(getArgumentValue ArgumentName.FileName)}=(?<{(getArgumentValue ArgumentName.FileName)}>.+))"

let getRegexForFileName () =
    new Regex(getFileNamePattern(), getRegexOptions())
