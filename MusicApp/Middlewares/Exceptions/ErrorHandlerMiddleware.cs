using System;
using System.Net;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MusicApp.Middlewares.Exceptions
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorResponse = Map(exception);
            context.Response.StatusCode = (int)(errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
            var response = errorResponse?.Response;
            if (response is null)
            {
                return;
            }

            await context.Response.WriteAsJsonAsync(response);
        }

        private ExceptionResponse Map(Exception exception)
        => exception switch
        {
            MusicException ex => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(new ErrorsResponse(new Error("błąd", "Wystąpił błąd")), HttpStatusCode.InternalServerError)
        };

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return type.Name.Underscore().Replace("_exception", string.Empty);
        }

        private class Error
        {
            public string Code { get; }
            public string Message { get; }

            public Error(string code, string message)
            {
                Code = code;
                Message = message;
            }
        }

        private class ErrorsResponse
        {
            public Error[] Errors { get; }

            public ErrorsResponse(params Error[] errors)
            {
                Errors = errors;
            }
        }

        public class ExceptionResponse
        {
            public object Response { get; }
            public HttpStatusCode StatusCode { get; }

            public ExceptionResponse(object response, HttpStatusCode statusCode)
            {
                Response = response;
                StatusCode = statusCode;
            }
        };
    }
}
