using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebMvcApi.Customs
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity != null && HttpContext.Current != null)
            {
                identity = HttpContext.Current.User.Identity;
            }
            if (identity != null && identity.IsAuthenticated)
            {
                var basicAuthIdentity = identity as BasicAuthenticationIdentity;
                if (basicAuthIdentity.Name == "admin" && basicAuthIdentity.Password == "1234")
                {
                    return true;
                }
            }
            return false;
        }
    }
}