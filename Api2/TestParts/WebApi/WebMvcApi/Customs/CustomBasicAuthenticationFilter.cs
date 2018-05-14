using System.Web.Http.Controllers;

namespace WebMvcApi.Customs
{
    public class CustomBasicAuthenticationFilter:BasicAuthenticationFilter
    {
        public override bool OnAuthorize(string userName, string userPassword, HttpActionContext actionContext)
        {
            if (userName == "admin" && userPassword == "1234")

                return true;
            else
                return false;
        }
    }
}