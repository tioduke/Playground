namespace WebApplicationFSharp.Net.Customers.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.FSharp.Linq.NullableOperators

open WebApplicationFSharp.Net.Customers.Models

[<Area("Customers")>]
type CustomerController () =
    inherit Controller()

    let _customers =
        [
            Customer (
                Id = Nullable 12,
                CustomerCode = "1001",
                CustomerName = "Asterix",
                NAS = "046454286",
                Amount = Nullable 90.34M,
                BirthDate = Nullable (DateTime(1008, 11, 01))
            );
            Customer (
                Id = Nullable 11,
                CustomerCode = "1002",
                CustomerName = "Obelix",
                NAS = "046454286",
                Amount = Nullable 91.00M,
                BirthDate = Nullable (DateTime(972, 10, 05))
            );
            Customer (
                Id = Nullable 0,
                CustomerCode = "0000",
                CustomerName = "",
                NAS = "000000000",
                Amount = Nullable 0.00M,
                BirthDate = Nullable (DateTime(0001, 01, 01))
            )
        ]

    // GET: /Customers/Customer/Index
    member this.Index () =
        this.View("CustomerForm") :> ActionResult

    // POST: /Customers/Customer/DisplayCustomer
    [<HttpPost>]
    member this.DisplayCustomer (obj: Customer) =
        if this.ModelState.IsValid then
            this.View("DisplayCustomer", obj) :> ActionResult
        else
            this.ModelState.AddModelError("Customer Form", "There are errors in the form, please correct.")
            this.View("CustomerForm", obj) :> ActionResult

    // GET: /Customers/Customer/DisplayCustomer
    member this.DisplayCustomer (id: int) =
        let findDefault customerList: Customer =
            List.find (fun x -> x.Id ?= 0) customerList
        let findById customerId customerList: Customer option =
            List.tryFind (fun x -> x.Id ?= customerId) customerList

        defaultArg (findById id _customers) (findDefault _customers) |> this.DisplayCustomer
