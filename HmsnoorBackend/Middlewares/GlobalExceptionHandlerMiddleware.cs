using System;
using System.Net;
using HmsnoorBackend.Middlewares.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Middlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                            Exception exception,
                                            CancellationToken cancellationToken)
    {
        string ErrorCode = string.Empty;

        switch (exception)
        {
            case KeyNotFoundException:
                ErrorCode = "E2011";
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            // case HttpRequestException:
            //     // httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            //     httpContext.Response.StatusCode = httpContext.Response.StatusCode;
            //     break;
            // case DbUpdateConcurrencyException:
            //     ErrorCode = "E8010";
            //     // httpContext.Response.StatusCode = 500
            //     break;
            case DbUpdateException:
                ErrorCode = "8020";
                httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                break;
            case Exception:
                // httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorCode = "E2000";
                httpContext.Response.StatusCode = httpContext.Response.StatusCode;
                break;
        }

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = (int)HttpStatusCode.NotFound,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            // problemDetail.Instance = httpContext.Request.Path;
            // problemDetail.Detail = exception;
        };

        BaseError error = new();
        error.Code = ErrorCode;
        error.Message = exception.Message;
        error.Url = httpContext.Request.Path;
        error.Details = exception.InnerException?.Message ?? "Error details not avaiable";

        _logger.LogError("Exception:: {problemDetail}", error);

        await httpContext.Response.WriteAsJsonAsync(error, cancellationToken).ConfigureAwait(false);

        return true;
    }
}
