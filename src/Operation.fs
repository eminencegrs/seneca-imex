module Operation

type OperationName =
    | Export
    | Import

let getOperationValue (operationName : OperationName) =
    match operationName with
    | OperationName.Export -> "export"
    | OperationName.Import -> "import"