using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPIApplication.Net.Mvc
{
   [DefaultStatusCode(DefaultStatusCode)]
    public class PayloadTooLargeResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status413PayloadTooLarge;

        public PayloadTooLargeResult([ActionResultObjectValue] object error)
            : base(error)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
