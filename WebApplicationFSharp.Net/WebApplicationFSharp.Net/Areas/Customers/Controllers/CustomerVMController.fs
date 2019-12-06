namespace WebApplicationFSharp.Net.Customers.Controllers

open Microsoft.AspNetCore.Mvc

open WebApplicationFSharp.Net.Customers.Models

[<Area("Customers")>]
type CustomerVMController () =
    inherit Controller()

    let _customer = CustomerViewModel (TxtName = "Panoramix", TxtAmount = "1000")

    // GET: /Customers/CustomerVM/DisplayCustomer
    member this.DisplayCustomer () =
        _customer |> this.View :> ActionResult
