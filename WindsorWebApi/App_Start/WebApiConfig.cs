using System.Web.Http;
using System.Web.Http.Cors;

namespace WindsorWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing. 
            // http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            // http://www.asp.net/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
            config.Filters.Add(new AuthorizeAttribute());

            // Uncomment to enable Cross-Origin Resource Sharing
            // (although I wouldn't recommend leaving the settings like this)
            // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            // var cors = new EnableCorsAttribute("*", "*", "*");
            // config.EnableCors(cors);
        }
    }
}
