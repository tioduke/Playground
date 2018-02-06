namespace WebApplicationFSharp.Net.Customers.Models

open System
open System.ComponentModel.DataAnnotations
open Microsoft.AspNetCore.Mvc

type Customer () =

    [<Required(ErrorMessage = "The field {0} is required")>]
    [<Range(10, 99)>]
    member val Id : Nullable<int> = Nullable() with get, set

    [<Required(ErrorMessage = "The field {0} is required")>]
    [<StringLength(4)>]
    member val CustomerCode : string = null with get, set

    [<StringLength(40)>]
    member val CustomerName : string = null with get, set

    member val NAS : string = null with get, set

    [<Required(ErrorMessage = "The field {0} is required")>]
    [<Remote("IsAmountValide", "Customer", AdditionalFields = "NAS", ErrorMessage = "The field {0} must be greater than zero if NAS is informed.")>]
    member val Amount : Nullable<decimal> = Nullable() with get, set

    [<DataType(DataType.Date)>]
    [<DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)>]
    member val BirthDate : Nullable<DateTime> = Nullable() with get, set

    [<DataType(DataType.Date)>]
    [<DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)>]
    member val OtherDate : Nullable<DateTime> = Nullable() with get, set
