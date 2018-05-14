using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebMvcApi.Customs
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private const string authenticationHeader = "WWW-Authenticate";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var crendetials = ParseHeader(request);

            if (crendetials != null)
            {
                var identity = new BasicAuthenticationIdentity(crendetials.Name, crendetials.Password);
                var principal = new GenericPrincipal(identity, null);

                Thread.CurrentPrincipal = principal;

                //针对于ASP.NET设置
                if (HttpContext.Current != null)
                    HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (crendetials == null && response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Challenge(request, response);
                }
                return response;
            });
        }

        private BasicAuthenticationIdentity ParseHeader(HttpRequestMessage request)
        {
            string authParameter = null;

            var authValue = request.Headers.Authorization;
            if (authValue != null && authValue.Scheme == "Basic")
                authParameter = authValue.Parameter;

            if (string.IsNullOrEmpty(authParameter))

                return null;

            authParameter = Encoding.Default.GetString(Convert.FromBase64String(authParameter));

            var authToken = authParameter.Split(':');
            if (authToken.Length < 2)
                return null;

            return new BasicAuthenticationIdentity(authToken[0], authToken[1]);
        }

        private void Challenge(HttpRequestMessage request, HttpResponseMessage response)
        {
            var host = request.RequestUri.DnsSafeHost;

            response.Headers.Add(authenticationHeader, string.Format("Basic realm=\"{0}\"", host));

        }
    }
}