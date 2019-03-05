using ExampleService.Domain.Exceptions;
using ExampleService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleService.Controllers
{
    [Route("api/example")]
    public class ExampleController
    {
        [HttpGet]
        public ApiResponse<ExampleResponse> Get()
        {
            var example = new ExampleResponse
            {
                Name = "My example",
                Type = ExampleType.Two
            };

            // Response with Example data
            return new ApiResponse<ExampleResponse>(example);
        }

        [HttpGet("with-exception")]
        public ApiResponse GetWithException([FromQuery] bool throwIt)
        {
            if (throwIt)
            {
                // Will be caught in middleware 
                throw new ExampleNotFoundException(ExampleErrorCodes.ExampleNotFound, "Example not found");
            }

            // Empty successful response
            return new ApiResponse();
        }
    }
}
