using AdsManagement.BuildingBlocks.Application;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagement.API.Configurations.Validations;

public class InvalidCommandProblemDetails : ProblemDetails
{
    public InvalidCommandProblemDetails(InvalidCommandException exception)
    {
        Title = "Command validation error";
        Status = StatusCodes.Status400BadRequest;
        Type = "https://somedomain/validation-error";
        Errors = exception.Errors;
    }

    public List<string> Errors { get; }
}