using Microsoft.Owin;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinDemo
{
    public class LoggerMiddleware : OwinMiddleware
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        public LoggerMiddleware(OwinMiddleware next)
            : base(next)
        {
        }


        public override async Task Invoke(IOwinContext context)
        {
            _logger.Debug("Logging middleware pipeline begin");
            _logger.Info("Incoming request uri: " + context.Request.Uri);
            await this.Next.Invoke(context);
            _logger.Debug("Logging middleware pipeline end");
        }
    }
}