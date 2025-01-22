using RecuperApp.Common;
using RecuperApp.Common.Models;
using ApplicationException = RecuperApp.Common.Exceptions.ApplicationException;
using System.Text.Json;
using System.Net;

namespace RecuperApp.Web.Gateway.Controllers
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private const string _responseType = "application/json; charset=UTF-8";

        public GlobalExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApplicationException ex)
            {
                if (!ex.AlreadyLoggedException)
                    StaticLogger.logger.Log(ex.LogLevel, ex, "CustomValidationsException caught by GlobalExceptionHandler.");
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = _responseType;
                var response = new HttpResponseModel(ex.Message);
                response.StatusCode = ex.StatusCode.GetHashCode();
                response.WasSuccessful = false;
                
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }
            catch (Exception ex)
            {
                ex.Data.Add("RESPONSE_CODE", 500);
                ex.Data.Add("RESPONSE_MESSAGE", ex.Message);
                StaticLogger.logger.Log(LogLevel.Error, ex, "Unexpected exception caught by GlobalExceptionHandler.");
                context.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                context.Response.ContentType = _responseType;
                var response = new HttpResponseModel()
                {
                    StatusCode = 500,
                    StatusMessage = "Ocurrio un error inesperado, por favor intente nuevamente o contacte al administrador del sistema sí el error es persistente.",
                    WasSuccessful = false
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }

        }

    }
}
