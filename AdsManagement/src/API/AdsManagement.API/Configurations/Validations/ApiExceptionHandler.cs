using AdsManagement.API.Common;
using AdsManagement.BuildingBlocks.Application;

using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace AdsManagement.API.Configurations.Validations;

public class ApiExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public ApiExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        var excDetails = exception switch
        {
            InvalidCommandException => (Detail: exception.Message, StatusCodes: StatusCodes.Status400BadRequest),
            _ => (Detail: exception.Message, StatusCodes: StatusCodes.Status500InternalServerError)
        };

        httpContext.Response.StatusCode = excDetails.StatusCodes;

        if (exception is InvalidCommandException invalidCommandException)
        {
            await httpContext.Response.WriteAsJsonAsync(new ApiResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Errors = invalidCommandException.Errors,
                IsSuccess = false,
            }, cancellationToken: cancellationToken);

            return true;
        }

        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = "An error occured",
                Detail = excDetails.Detail,
                Type = excDetails.GetType().Name,
                Status = excDetails.StatusCodes
            },
            Exception = exception
        });
    }
}