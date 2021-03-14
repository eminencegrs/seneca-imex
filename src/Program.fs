open Microsoft.Extensions.Logging
open ArgumentsProcessing
open Logging
open Handler

[<EntryPoint>]
let main argv =

    let logger = getLogger()

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

    0
