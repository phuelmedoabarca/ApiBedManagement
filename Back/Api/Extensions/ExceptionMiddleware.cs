using Azure;
using Domain.Excepcions;
using System.Net;

namespace Api.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = exception switch
            {
                BadRequestException badRequestException => badRequestException.Message,
                NotFoundException notFoundException => $"No se encuentra {notFoundException.Message}",
                _ => exception.Message
            };


            await context.Response.WriteAsync(new ResponseDetalle()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
