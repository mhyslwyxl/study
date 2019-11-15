using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jwt.Gateway.Controllers
{
    public enum ApiActionFilterAttributeOption
    {
        OR, AND
    }
    public class ApiActionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        List<string> Permissions = new List<string>();
        ApiActionFilterAttributeOption Option = ApiActionFilterAttributeOption.AND;
        public ApiActionFilterAttribute(string permission)
        {
            Permissions.Add(permission);
        }
        public ApiActionFilterAttribute(string[] permissions, ApiActionFilterAttributeOption option)
        {
            foreach (var permission in permissions)
            {
                if (Permissions.Contains(permission))
                {
                    continue;
                }
                Permissions.Add(permission);
            }
            Option = option;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var key = GetAppKey(context);
            List<string> keyPermissions = GetAppKeyPermissions(key);
            var isAnd = Option == ApiActionFilterAttributeOption.AND;
            var permissionsCount = Permissions.Count;
            var keyPermissionsCount = keyPermissions.Count;
            for (var i = 0; i < permissionsCount; i++)
            {
                bool flag = false;
                for (var j = 0; j < keyPermissions.Count; j++)
                {
                    if (flag = string.Equals(Permissions[i], keyPermissions[j], StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                if (isAnd)
                {
                    throw new Exception("应用“" + key + "”缺少“" + Permissions[i] + "”的权限");
                }
            }

            context.HttpContext.Items.Add("Permissions", Permissions);

            base.OnActionExecuting(context);
        }

        private string GetAppKey(ActionExecutingContext context)
        {
            var claims = context.HttpContext.User.Claims;
            if (claims == null)
            {
                throw new Exception("未能获取到应用标识");
            }
            var claimKey = claims.ToList().Find(o => string.Equals(o.Type, "AppKey", StringComparison.OrdinalIgnoreCase));
            if (claimKey == null)
            {
                throw new Exception("未能获取到应用标识");
            }

            return claimKey.Value;
        }
        private List<string> GetAppKeyPermissions(string appKey)
        {
            List<string> li = new List<string>
            {
                "用户明细","用户列表","用户录入","用户修改","用户删除"
            };
            return li;
        }

    }
}