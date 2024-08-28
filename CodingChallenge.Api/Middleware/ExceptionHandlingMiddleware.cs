using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CodingChallenge.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred.");

            var problemDetailsFactory = context.RequestServices.GetRequiredService<ProblemDetailsFactory>();
            ProblemDetails problemDetails;

            switch (ex)
            {
                case ValidationException validationException:
                    problemDetails = CreateValidationProblemDetails(context, problemDetailsFactory, validationException);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ArgumentException argumentException:
                    problemDetails = CreateArgumentProblemDetails(context, problemDetailsFactory, argumentException);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    problemDetails = CreateInternalServerErrorProblemDetails(context, problemDetailsFactory);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private ValidationProblemDetails CreateValidationProblemDetails(HttpContext context, ProblemDetailsFactory problemDetailsFactory, ValidationException exception)
    {
        var modelState = new ModelStateDictionary();
        foreach (var error in exception.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        var validationProblemDetails = problemDetailsFactory.CreateValidationProblemDetails(
            context,
            modelState,
            statusCode: StatusCodes.Status400BadRequest,
            title: "Validation error",
            detail: "See the errors property for details.",
            instance: context.Request.Path
        );

        return validationProblemDetails;
    }

    private ProblemDetails CreateArgumentProblemDetails(HttpContext context, ProblemDetailsFactory problemDetailsFactory, ArgumentException exception)
    {
        var problemDetails = problemDetailsFactory.CreateProblemDetails(
            context,
            StatusCodes.Status400BadRequest,
            "Invalid argument",
            exception.Message,
            context.Request.Path
        );

        return problemDetails;
    }

    private ProblemDetails CreateInternalServerErrorProblemDetails(HttpContext context, ProblemDetailsFactory problemDetailsFactory)
    {
        var problemDetails = problemDetailsFactory.CreateProblemDetails(
            context,
            StatusCodes.Status500InternalServerError,
            "An unexpected error occurred",
            "An unexpected error occurred while processing your request.",
            context.Request.Path
        );

        return problemDetails;
    }
}