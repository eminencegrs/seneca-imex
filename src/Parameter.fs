module Seneca.Imex.Parameter

type Parameter =
    | Task
    | Target
    | FileName

let getParameter (parameter : Parameter) =
    match parameter with
    | Parameter.Task -> "task"
    | Parameter.Target -> "target"
    | Parameter.FileName -> "filename"