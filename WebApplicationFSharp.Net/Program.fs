﻿namespace WebApplicationFSharp.Net

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging

module Program =
    let exitCode = 0

    let BuildWebHost args =
        WebHost
            .CreateDefaultBuilder(args)
            .UseUrls("http://0.0.0.0:5000/")
            .UseStartup<Startup>()
            .Build()

    [<EntryPoint>]
    let main args =
        BuildWebHost(args).Run()

        exitCode
