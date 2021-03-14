module Argument

type ArgumentName =
    | Task
    | Target
    | FileName

let getArgumentValue (argumentName : ArgumentName) =
    match argumentName with
    | ArgumentName.Task -> "task"
    | ArgumentName.Target -> "target"
    | ArgumentName.FileName -> "filename"