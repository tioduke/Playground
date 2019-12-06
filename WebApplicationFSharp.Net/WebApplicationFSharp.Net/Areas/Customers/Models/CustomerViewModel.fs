namespace WebApplicationFSharp.Net.Customers.Models

open System
open Microsoft.FSharp.Linq.NullableOperators

type CustomerViewModel () =

    let _customer = Customer()

    member this.TxtName
        with get () = _customer.CustomerName
        and set value = _customer.CustomerName <- value

    member this.TxtAmount
        with get () = _customer.Amount.ToString()
        and set (value: string) = _customer.Amount <- Nullable <| Convert.ToDecimal(value)

    member this.CustomerLevelColor
        with get () =
            match _customer.Amount with
            | x when x ?> 2000.00M -> "red"
            | x when x ?> 1500.00M -> "orange"
            | _ -> "yellow"
