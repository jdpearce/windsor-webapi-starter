using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

using WindsorWebApi.Model;

namespace WindsorWebApi.Services
{
    /// <summary>
    /// An illustration of how we can capture and rewrite exceptions
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var errorInfo = new ErrorInfo
            {
                Type =  "Unexpected",
                Message = context.Exception.Message
            };

            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent(typeof(ErrorInfo), errorInfo, new JsonMediaTypeFormatter())
                };
        }
    }
}