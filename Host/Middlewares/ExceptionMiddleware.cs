using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Host.Middlewares;

internal class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch(OperationCanceledException) { }
        catch (Exception exception)
        {
            // 1) Generas tu ErrorResult
            string errorId = Guid.NewGuid().ToString();
            var errorResult = new ErrorResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName,
                Exception = exception.Message.Trim(),
                ErrorId = errorId,
            };
            errorResult.Messages!.Add(exception.Message);
            var response = context.Response;
            response.ContentType = "application/json";
            
            // 2) Si no es CustomException, baja hasta la excepción raíz
            if (exception is not CustomException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            // 3) Manejo explícito de MySQL caído
            if (exception is MySqlException
                || (exception is DbUpdateException dbEx && dbEx.InnerException is MySqlException))
            {
                response.StatusCode = errorResult.StatusCode = StatusCodes.Status503ServiceUnavailable;
                errorResult.Messages = new List<string>
                {
                    "Servicio de base de datos no disponible. Inténtalo de nuevo más tarde."
                };
            }
            else
            {
                // 4) Resto de tu switch habitual
                switch (exception)
                {
                    case CustomException ce:
                        response.StatusCode = errorResult.StatusCode = (int)ce.StatusCode;
                        if (ce.ErrorMessages is not null)
                            errorResult.Messages = ce.ErrorMessages;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
            }

            var result = JsonSerializer.Serialize(errorResult);

            await response.WriteAsync(result);
        }
    }
}