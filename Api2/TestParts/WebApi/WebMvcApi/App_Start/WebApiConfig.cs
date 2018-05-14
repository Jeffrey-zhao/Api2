using System.Web.Http;
using WebMvcApi.Customs;

namespace WebMvcApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.Filters.Add(new CustomBasicAuthenticationFilter());

            config.MessageHandlers.Add(new BasicAuthenticationHandler());
            config.Filters.Add(new BasicAuthenticationAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
