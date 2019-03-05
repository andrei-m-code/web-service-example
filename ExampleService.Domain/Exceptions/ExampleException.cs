using System;
using System.Net;

namespace ExampleService.Domain.Exceptions
{
    public abstract class ExampleException : Exception
    {
        public int Code { get; }

        public abstract HttpStatusCode Status { get; }

        protected ExampleException(int code, string message) :  base(message)
        {
            Code = code;
        }
    }
}
