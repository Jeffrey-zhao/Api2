using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using WebAppHttpMessageHandler.Customs;

namespace WebAppHttpMessageHandler.Controllers
{
    public class Demo2Controller : ApiController
    {
        public IEnumerable<string> Get()
        {
            MyHttpServer httpServer = new MyHttpServer();

            Thread.CurrentPrincipal = null;
            HttpRequestMessage request = new HttpRequestMessage();
            httpServer.SendAsync(request, new CancellationToken(false));
            GenericPrincipal principal = Thread.CurrentPrincipal as GenericPrincipal;
            string identity1 = string.IsNullOrEmpty(principal.Identity.Name) ? "N/A" : principal.Identity.Name;

            GenericIdentity identity = new GenericIdentity("jeffrey");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, new string[0]);
            request = new HttpRequestMessage();
            httpServer.SendAsync(request, new CancellationToken(false));
            principal = Thread.CurrentPrincipal as GenericPrincipal;
            string identity2 = string.IsNullOrEmpty(principal.Identity.Name) ? "N/A" : principal.Identity.Name;
            return new string[] { identity1, identity2 };
        }
    }
}
