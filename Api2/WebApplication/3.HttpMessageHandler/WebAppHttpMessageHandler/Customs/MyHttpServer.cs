using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebAppHttpMessageHandler.Customs
{
    public class MyHttpServer : HttpServer
    {
        public MyHttpServer() : base() { }
        public MyHttpServer(HttpConfiguration configuration) : base(configuration)
        {

        }

        public new void Initialize()
        {
            base.Initialize();
        }

        public new Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}