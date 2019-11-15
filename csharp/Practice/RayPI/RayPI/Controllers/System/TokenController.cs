using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RayPI.AuthHelper;
using RayPI.Token;
using RayPI.Token.Model;

namespace RayPI.Controllers.System
{
    [Route("api/system/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Token(string name, string pass)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            // 获取用户的角色名，请暂时忽略其内部是如何获取的，可以直接用 var userRole="Admin"; 来代替更好理解。
            string userRole = ""; // await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
            if (name.ToLower() == "admin")
                userRole = "Admin";
            else if (name.ToLower() == "System")
                userRole = "System";
            else if (name.ToLower() != "")
                userRole = "User";

            if (userRole != "")
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModel tokenModel = new TokenModel { Uid = 1, Role = userRole };
                //jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                jwtStr = RayPIToken.IssueJWT(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
    }
}