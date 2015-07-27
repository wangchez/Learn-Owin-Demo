using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OwinDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_AuthenticateRequest()
        //{
        //    var claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.Name, "UDN"));
        //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        //    claims.Add(new Claim(ClaimTypes.Email, "udn@123"));

        //    var identity = new ClaimsIdentity(claims, "AnonymousLogin");
        //    var principal = new ClaimsPrincipal(identity);

        //    HttpContext.Current.User = principal;
        //}
    }
}
