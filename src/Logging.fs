namespace Seneca.Imex

open Microsoft.Extensions.Logging

module Logging =

    let getLogger () =
        use factory = LoggerFactory.Create(fun b -> b.AddConsole() |> ignore)
        factory.CreateLogger()
