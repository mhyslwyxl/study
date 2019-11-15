using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.MiddleWare
{
    public static class InterceptHandler
    {
        public static IApplicationBuilder UseInterceptMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<InterceptMiddlware>();
        }
    }
}
