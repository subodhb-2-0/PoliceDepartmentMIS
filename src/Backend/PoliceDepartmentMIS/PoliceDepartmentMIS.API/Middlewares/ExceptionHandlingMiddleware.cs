using PoliceDepartmentMIS.Core.Dtos.Common;
using System.Net;
using System.Text.Json;

namespace PoliceDepartmentMIS.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;  // Access to the current environment (Development, Production, etc.)
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Continue with the request pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Set the response status code to 500 (Internal Server Error)
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Create the response body
                var response = new Response<string>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = null
                };

                // Environment-specific error message
                if (_env.IsDevelopment())
                {
                    response.Message = ex.Message;  // Include actual exception message in development
                }
                else
                {
                    response.Message = "An unexpected error occurred. Please try again later.";  // Generic message in production
                }

                // Serialize the response object to JSON and write it to the response body
                context.Response.ContentType = "application/json";
                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
