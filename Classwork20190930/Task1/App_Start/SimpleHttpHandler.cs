using System.Web;
using System.Web.Routing;

namespace CustomHttpHandler.App_Start
{
    public class SimpleHttpHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }
        public SimpleHttpHandler(RequestContext reqcon)
        {
            RequestContext = reqcon;
        }
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hello, world!");
        }
    }
}