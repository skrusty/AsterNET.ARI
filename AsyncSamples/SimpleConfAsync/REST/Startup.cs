using Owin;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace SimpleConfAsync.REST
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithAction",
            //    routeTemplate: "api/{controller}/{id}/{action}",
            //    defaults: new { action = "Get" },
            //    constraints: new { HttpCons}
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithId",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiGet",
                routeTemplate: "api/{controller}/",
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiPost",
                routeTemplate: "api/{controller}/",
                defaults: new { action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiDelete",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );
            appBuilder.UseWebApi(config);
        }
    }
}
