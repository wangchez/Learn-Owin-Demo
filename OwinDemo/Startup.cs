using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;

//2.OwinStartup Attribute:
//[assembly: OwinStartupAttribute(typeof(OwinDemo.StartupForOwinAttribute))]
//[assembly: OwinStartupAttribute("StartupConfig", typeof(OwinDemo.StartupFromAppSetting))]
//[assembly: OwinStartupAttribute("StartupConfig", typeof(OwinDemo.StartupFromAppSetting), "AuthConfiguration")]
namespace OwinDemo
{
    //1.Naming Convention:Startup
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Generator Middleware Type
            app.Use<LoggerMiddleware>();
            app.Use<DoNotContactMe>();

            // Contructor Type
            //app.Use(typeof(DoNotContactMe));

            // Instance Middleware Type
            //app.Use(new DoNotContactMe());

            //Delegate Type
            app.Use(async (context, next) =>
            {
                //Do something...
                await next.Invoke();
            });

            // additional middleware registrations

            ConfigureAuth(app);
        }
    }

    public class StartupForOwinAttribute
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }

    public class StartupFromAppSetting
    {
        public void Configuration(IAppBuilder app)
        {
        }

        public void AuthConfiguration(IAppBuilder app)
        {
        }
    }
}


