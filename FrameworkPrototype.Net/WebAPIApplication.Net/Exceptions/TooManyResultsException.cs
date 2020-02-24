using System;
using Microsoft.AspNetCore.Http;

namespace WebAPIApplication.Net.Exceptions
{
    [Serializable]
    public sealed class TooManyResultsException : Exception
    {
        public string Title => "Too many results";
        public int Status => StatusCodes.Status416RangeNotSatisfiable;

        public TooManyResultsException(string message)
            : base(message)
        {
        }
    }
}