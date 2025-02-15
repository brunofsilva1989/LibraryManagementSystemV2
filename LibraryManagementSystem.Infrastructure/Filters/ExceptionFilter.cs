using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;


namespace LibraryManagementSystem.Infrastructure.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing your request.",
                Error = context.Exception.Message
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = context.Exception switch
                {
                    ArgumentNullException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
