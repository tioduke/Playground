namespace WebApplicationFSharp.Net.Customers.Models

open System
open System.ComponentModel.DataAnnotations
open Microsoft.AspNetCore.Mvc

type Customer () =

    [<Required(ErrorMessage = "The field {0} is required")>]
    [<Range(10, 99)>]
    member val Id : int = null with get, set

    [<Required(ErrorMessage = "The field {0} is required")>]
    [<StringLength(4)>]
    member val CustomerCode : string = null with get, set

    [<StringLength(40)>]
    member val CustomerName : string = null with get, set

    member val NAS : string = null with get, set

    [<Required(ErrorMessage = "The field {0} is required")>]
    member val Amount : decimal = null with get, set

    [<DataType(DataType.Date)>]
    [<DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)>]
    member val BirthDate : DateTime = null with get, set

    [<DataType(DataType.Date)>]
    [<DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)>]
    member val OtherDate : DateTime = null with get, set
