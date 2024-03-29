﻿open Microsoft.Extensions.Logging
open Seneca.Imex.Logging
open Seneca.Imex.ImportExportHandler
open Seneca.Imex.ParametersHandler

[<EntryPoint>]
let main argv =
    let logger = getLogger()
    try
        logger.LogInformation "Started processing arguments..."
        let fileName = getFileName argv
        logger.LogInformation("The file name: {fileName}", fileName)
        let operation = getOperation argv
        logger.LogInformation("The operation: {operation}", operation)
        let target = getTarget argv
        logger.LogInformation("Target: {target}", target)
        logger.LogInformation("Processing environment variables...")
        handle operation fileName target
        logger.LogInformation("Environment variables have been processed.")
    with
        | ex -> logger.LogError(ex.Message)
    0
