using Core.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Mediatr.Demo.Api.Helpers
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, HttpStatusCode> exceptionHandlerDictionary = new Dictionary<Type, HttpStatusCode>()
        {
            {typeof(NotFoundException), HttpStatusCode.NotFound},
            {typeof(AlreadyExistsException), HttpStatusCode.Conflict},
            {typeof(ValidationException), HttpStatusCode.BadRequest},
            {typeof(NotAcceptableException), HttpStatusCode.NotAcceptable},
            {typeof(NotAllowedException), HttpStatusCode.MethodNotAllowed },
        };

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode resultStatusCode;
            if (!exceptionHandlerDictionary.TryGetValue(actionExecutedContext.Exception.GetType(), out resultStatusCode))
            {
                resultStatusCode = HttpStatusCode.InternalServerError;
            }

            if (resultStatusCode == HttpStatusCode.InternalServerError)
            {
#if DEBUG
                throw new HttpResponseException(actionExecutedContext.Request.CreateErrorResponse(resultStatusCode, actionExecutedContext.Exception));
#else
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                       resultStatusCode, "There has been internal server error, please try again later or contact support");
#endif
            }
            else
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                       resultStatusCode, actionExecutedContext.Exception.Message);
            }
        }
    }
}