using System;
using System.Net;

namespace PaninApi.Abstractions.Exceptions
{
    public abstract class BaseProblemDetailsException : Exception
    {
        public string Title { get; }

        public string Detail { get; }

        public HttpStatusCode? HttpStatusCode { get; }

        protected BaseProblemDetailsException(string title, string detail, HttpStatusCode? httpStatusCode)
        {
            Title = title;
            Detail = detail;
            HttpStatusCode = httpStatusCode;
        }
    }
}