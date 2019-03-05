using System;
using ExampleService.Domain.Exceptions;

namespace ExampleService.Models
{
    public class ApiResponse
    {
        public class ApiResponseError
        {
            public int Code { get; }

            public string Message { get; }

            public ApiResponseError(Exception exception)
            {
                Message = exception.Message;

                if (exception is ExampleException ex)
                {
                    Code = ex.Code;
                }
            }
        }

        public ApiResponseError Error { get; }

        public ApiResponse()
        {
        }

        public ApiResponse(Exception exception)
        {
            Error = new ApiResponseError(exception);
        }
    }

    public class ApiResponse<TData> : ApiResponse
    {
        public TData Data { get; }

        public ApiResponse(TData data)
        {
            Data = data;
        }

        public ApiResponse(Exception exception) : base(exception)
        {
        }
    }
}
