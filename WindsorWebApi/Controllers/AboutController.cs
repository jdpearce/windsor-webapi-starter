using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

using WindsorWebApi.Model;

namespace WindsorWebApi.Controllers
{
    [AllowAnonymous]
    public class AboutController : ApiController
    {
        [Route("About")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new AboutInfo
                {
                    Name = "WindsorWebApi",
                    Description = "A test project that includes a few pre-configured packages/patterns and illustrates their usage.",
                    Version = Assembly.GetExecutingAssembly().ImageRuntimeVersion
                });
        }
    }
}