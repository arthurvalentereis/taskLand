using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using TaskLand.API.Exceptions;
using TaskLand.API.Model;

namespace TaskLand.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var customizeMessage = error?.Message;

                switch (error)
                {
                    case AppException:
                    case ArgumentException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        customizeMessage = "Ocorreu um erro inesperado, tente novamente mais tarde";
                        break;
                }
                var result = JsonSerializer.Serialize(new ErrorMessage { Message = customizeMessage });
                await response.WriteAsync(result);
            }
        }
    }
}
