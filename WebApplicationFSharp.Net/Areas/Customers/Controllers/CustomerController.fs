namespace WebApplicationFSharp.Net.Customers.Controllers

open System
open System.Collections.Generic
open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.FSharp.Linq.NullableOperators

open WebApplicationFSharp.Net.Customers.Models

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
                BirthDate = Nullable (new DateTime(1008, 11, 1))
            );
            Customer (
                Id = Nullable 11,
                CustomerCode = "1002",
                CustomerName = "Obelix",
                NAS = "046454286",
                Amount = Nullable 91.00M,
                BirthDate = Nullable (new DateTime(972, 10, 5))
            );
            Customer (
                Id = Nullable 0,
                CustomerCode = "0000",
                CustomerName = "",
                NAS = "000000000",
                Amount = Nullable 0.00M,
                BirthDate = Nullable (new DateTime(1, 1, 5))
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
        let filter (liste: Customer list): Customer =
            List.find (fun x -> x.Id ?= id) liste

        filter _customers |> this.DisplayCustomer
        //let temp =
        //    List.tryFind (fun x -> x.Id = id) _customers
        //    |> fun temp2 ->
        //        match temp2 with
        //        | None -> List.find (fun x -> x.Id = 0) _customers
        //        | _ -> Some temp2

        //this.DisplayCustomer temp
