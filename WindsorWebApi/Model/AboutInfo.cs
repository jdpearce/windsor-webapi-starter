using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace WindsorWebApi.Model
{
    public class AboutInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}