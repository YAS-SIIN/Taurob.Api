using Microsoft.OpenApi.Extensions;
using System.Text.Json;
using Taurob.Api.Domain.DTOs;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Presentation.Shared.Exceptions;

namespace Taurob.Api.Presentation.WebApi.Middlewares;

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
   
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        { 
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = (int)EnumResponseStatus.BadRequest;
        ErrorException errorException = new ErrorException(statusCode, (int)EnumResponseResultCodes.Error, EnumResponseResultCodes.Error.GetDisplayName());
        IDictionary<string, string[]> errors = new Dictionary<string, string[]>();
        try
        {
            errorException = ((ErrorException)exception);
        }
        catch { }
        try
        {
            statusCode = GetStatusCode(exception);
        }
        catch { }
        try
        {
            errors = GetErrors(exception);
        }
        catch { }

        var errorData = ResultDto<ErrorDto>.ReturnData(null, statusCode, (int)errorException?.ErrorCode, exception?.Message, errorException.ErrorDescription, errors);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorData));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        { 
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            ErrorException => StatusCodes.Status400BadRequest,
            ForbiddenAccessException => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

    private static IDictionary<string, string[]> GetErrors(Exception exception)
    {
        IDictionary<string, string[]> errors = null;

        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors;
        }

        return errors;
    }
}
