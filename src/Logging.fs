module Logging

open Microsoft.Extensions.Logging

let getLogger () =
    use factory = LoggerFactory.Create(fun b -> b.AddConsole() |> ignore)
    factory.CreateLogger()