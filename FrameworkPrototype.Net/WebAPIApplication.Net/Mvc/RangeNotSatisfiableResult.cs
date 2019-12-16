using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPIApplication.Net.Mvc
{
   [DefaultStatusCode(DefaultStatusCode)]
    public class RangeNotSatisfiableResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status416RangeNotSatisfiable;

        public RangeNotSatisfiableResult([ActionResultObjectValue] object error)
            : base(error)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
