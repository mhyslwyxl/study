using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutoFacDemo.MiddleWare
{
    public class InterceptMiddlware
    {
        private readonly RequestDelegate _next;

        public InterceptMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            PreProceed(context);
            await _next(context);
            PostProceed(context);
        }

        private void PreProceed(HttpContext context)
        {
            Console.WriteLine($"{DateTime.Now} middleware invoke preproceed----------中间件前");
        }

        private void PostProceed(HttpContext context)
        {
            Console.WriteLine($"{DateTime.Now} middleware invoke postproceed----------中间件后");
        }
    }
}