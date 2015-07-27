using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace OwinDemo
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    using Microsoft.Owin;
    public class DoNotContactMe
    {
        private AppFunc _next;

        public DoNotContactMe(AppFunc next)
        {
            _next = next;
        }

        public void Initialize(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            //IOwinContext owinContext = new OwinContext(environment);
            HttpContextBase httpContext = (HttpContextBase)environment.Single(context => 
                context.Key == "System.Web.HttpContextBase").Value;
            var url = httpContext.Request.Url;
            if (url.AbsoluteUri.Contains("/Contact"))
            {
                httpContext.Response.Redirect("/");
            }
            else
            {
                await this._next.Invoke(environment);
            }
        }

    }
}