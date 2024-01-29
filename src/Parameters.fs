namespace Seneca.Imex

module Parameters =

    type ParameterType =
        | Task
        | Target
        | FileName

    let getParameter (parameter: ParameterType) =
        match parameter with
        | ParameterType.Task        -> "task"
        | ParameterType.Target      -> "target"
        | ParameterType.FileName    -> "filename"
