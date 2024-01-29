namespace Seneca.Imex

open System.Text.RegularExpressions
open Operations
open Parameters

module Regex =

    let getRegexOptions () =
        RegexOptions.Compiled ||| RegexOptions.IgnoreCase ||| RegexOptions.CultureInvariant;

    let getTaskPattern () =
        $"(--{(getParameter ParameterType.Task)}=(?<{(getParameter ParameterType.Task)}>({(getOperation OperationType.Export)})|({(getOperation OperationType.Import)})))"

    let getRegexForTask () =
        new Regex(getTaskPattern(), getRegexOptions())

    let getTargetPattern () =
        $"(--{(getParameter ParameterType.Target)}=(?<{(getParameter ParameterType.Target)}>.+))"

    let getRegexForTarget () =
        new Regex(getTargetPattern(), getRegexOptions())

    let getFileNamePattern () =
        $"(--{(getParameter ParameterType.FileName)}=(?<{(getParameter ParameterType.FileName)}>.+))"

    let getRegexForFileName () =
        new Regex(getFileNamePattern(), getRegexOptions())
