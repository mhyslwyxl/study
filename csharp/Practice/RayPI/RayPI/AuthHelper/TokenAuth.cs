using Microsoft.AspNetCore.Http;
using RayPI.Token;
using RayPI.Token.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using SqlSugar;

namespace RayPI.AuthHelper
{
    /// <summary>
    /// Token验证授权中间件
    /// </summary>
    public class TokenAuth
    {
        /// <summary>
        /// http委托
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public TokenAuth(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 验证授权
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers;
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!headers.ContainsKey("Authorization"))
            {
                return _next(httpContext);
            }
            var tokenStr = headers["Authorization"];
            try
            {
                string jwtStr = tokenStr.ToString().Substring("Bearer ".Length).Trim();
                //验证缓存中是否存在该jwt字符串
                //if (!RayPIMemoryCache.Exists(jwtStr))
                //{
                //    return httpContext.Response.WriteAsync("非法请求");
                //}
                //TokenModel tm = ((TokenModel)RayPIMemoryCache.Get(jwtStr));
                //TokenModel tm = ((TokenModel)RayPIMemoryCache.Get("1"));
                //提取tokenModel中的Sub属性进行authorize认证
                if (jwtStr.Length >= 128)
                {
                    //Console.WriteLine($"{DateTime.Now} token :{tokenHeader}");
                    TokenModel tm = SerializeJwt(jwtStr);

                    //授权
                    //var claimList = new List<Claim>();
                    //var claim = new Claim(ClaimTypes.Role, tm.Role);
                    //claimList.Add(claim);
                    //var identity = new ClaimsIdentity(claimList);
                    //var principal = new ClaimsPrincipal(identity);
                    //httpContext.User = principal;
                    
                    List<Claim> lc = new List<Claim>();
                    Claim c = new Claim(ClaimTypes.Role, tm.Role);
                    lc.Add(c);
                    ClaimsIdentity identity = new ClaimsIdentity(lc);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    httpContext.User = principal;
                }
                return _next(httpContext);
            }
            catch (Exception)
            {
                return httpContext.Response.WriteAsync("token验证异常");
            }
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModel SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role;
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModel
            {
                Uid = (jwtToken.Id).ObjToInt(),
                Role = role != null ? role.ObjToString() : "",
            };
            return tm;
        }
    }
}