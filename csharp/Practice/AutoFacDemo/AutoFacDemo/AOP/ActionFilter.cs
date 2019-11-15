using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFacDemo.AOP
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{DateTime.Now} on action exceuting--过滤器前");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{DateTime.Now} on action exceuted--过滤器后");
        }
    }
}
