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
            //log.Log("Something happened")
            return new ApiResponse<ExampleResponse>(example);
        }

        [HttpGet("with-exception")]
        public ApiResponse GetWithException()
        {
            // Will be caught in middleware 
            throw new ExampleNotFoundException(ExampleErrorCodes.ExampleNotFound, "Example not found");

            return new ApiResponse();
        }
    }
}
