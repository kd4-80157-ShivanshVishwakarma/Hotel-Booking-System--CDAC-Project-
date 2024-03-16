using MyErrorLoggerLib;
using Newtonsoft.Json;
using WebHotelBooking.Models;

namespace WebHotelBooking.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly IErrorLogger _errorLogger;

        public ExceptionMiddleware(RequestDelegate nextMiddleware, IErrorLogger errorLogger)
        {
            _nextMiddleware = nextMiddleware;
            _errorLogger = errorLogger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nextMiddleware(context);
            }
            catch(Exception ex)
            {
                _errorLogger.LogEntry(ex);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var error = new Error
                {
                    Message = ex.Message,
                    Source = ex.Source
                };
                var result = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(result);
            }
            
        }
    }
}
