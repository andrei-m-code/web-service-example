using System.Net;

namespace ExampleService.Domain.Exceptions
{
    public class ExampleNotFoundException : ExampleException
    {
        public override HttpStatusCode Status => HttpStatusCode.NotFound;

        public ExampleNotFoundException(int code, string message) : base(code, message)
        {
        }
    }
}
