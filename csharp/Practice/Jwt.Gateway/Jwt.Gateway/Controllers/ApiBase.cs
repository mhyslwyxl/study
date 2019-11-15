using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jwt.Gateway.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ApiBase : Microsoft.AspNetCore.Mvc.Controller
    {
        private string _CurrentAppKey = "";
        public string CurrentAppKey { get { return _CurrentAppKey; } }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var claims = context.HttpContext.User.Claims.ToList();
            var claim = claims.Find(o => o.Type == "appKey");
            if (claim == null)
            {
                throw new Exception("未通过认证");
            }
            var appKey = claim.Value;
            if (string.IsNullOrEmpty(appKey))
            {
                throw new Exception("appKey不合法");
            }

            _CurrentAppKey = appKey;

            base.OnActionExecuting(context);
        }
    }
}