namespace Seneca.Imex

module Operations =

    type OperationType =
        | Export
        | Import

    let getOperation (operation: OperationType) =
        match operation with
        | OperationType.Export -> "export"
        | OperationType.Import -> "import"
