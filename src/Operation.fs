module Seneca.Imex.Operation

type Operation =
    | Export
    | Import

let getOperation (operation : Operation) =
    match operation with
    | Operation.Export -> "export"
    | Operation.Import -> "import"