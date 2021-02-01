using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PaninApi.Abstractions.Exceptions;

namespace PaninApi.WebApi.Filters
{
    public class ProblemExceptionFilter : IExceptionFilter
    {
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        protected ProblemExceptionFilter(ProblemDetailsFactory problemDetailsFactory)
        {
            _problemDetailsFactory = problemDetailsFactory;
        }

        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is BaseProblemDetailsException exception))
            {
                context.ExceptionHandled = false;
                return;
            }

            var problemDetails = _problemDetailsFactory.CreateProblemDetails(
                context.HttpContext,
                (int?) exception.HttpStatusCode ?? StatusCodes.Status500InternalServerError,
                exception.Title,
                detail: exception.Detail
            );

            var objectResult = new ObjectResult(problemDetails);
            objectResult.StatusCode = problemDetails.Status;

            context.Result = objectResult;
        }
    }
}