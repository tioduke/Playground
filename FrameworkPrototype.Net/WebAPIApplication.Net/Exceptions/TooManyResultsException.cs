using System;
using System.Net;

namespace WebAPIApplication.Net.Exceptions
{
    [Serializable]
    public sealed class TooManyResultsException : Exception
    {
        public const string Title = "Too many results";
        public const int Status = (int)HttpStatusCode.RequestedRangeNotSatisfiable;

        public TooManyResultsException(string message)
            : base(message)
        {
        }
    }
}