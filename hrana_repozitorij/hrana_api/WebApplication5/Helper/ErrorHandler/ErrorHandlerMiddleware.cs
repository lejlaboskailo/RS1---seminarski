using NPOI.HSSF.Record.Chart;
using NPOI.SS.Formula.Functions;
using System.Net;
using System.Text.Json;
using WebApplication5.Data;
using WebApplication5.EntityModels;
using WebApplication5.Service;
using XAct.Library.Settings;

namespace WebApplication5.Helper.ErrorHandler
{
    public class ErrorHandlerMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IEmailService emailService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

               // emailService.sendMail(error.Message);

                switch (error)
                {
                    case ErrorResponse e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var message = error.Message;
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}