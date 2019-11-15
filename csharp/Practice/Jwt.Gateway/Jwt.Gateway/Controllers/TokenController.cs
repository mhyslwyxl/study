using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Gateway.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenController : Controller
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public TokenController(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // /api/token/get
        public IActionResult Get(string appKey, string appPassword)
        {
            appKey = "myKey";
            appPassword = "myPassword";
            try
            {
                if (string.IsNullOrEmpty(appKey))
                {
                    throw new Exception("缺少appKey");
                }
                if (string.IsNullOrEmpty(appKey))
                {
                    throw new Exception("缺少appPassword");
                }
                if (appKey != "myKey" && appPassword != "myPassword")//固定的appKey及appPassword，实际项目中应该来自数据库或配置文件
                {
                    throw new Exception("配置不存在");
                }

                var key = new Microsoft.IdentityModel.Tokens
                    .SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
                var creds = new Microsoft.IdentityModel.Tokens
                    .SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
                var claims = new List<System.Security.Claims.Claim>();
                claims.Add(new System.Security.Claims.Claim("appKey", appKey)); //仅在Token中记录appKey
                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                        issuer: _configuration["JwtTokenIssuer"],
                        audience: _configuration["JwtTokenAudience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds);

                return Ok(new Models.ApiResponse { status = 1, message = "OK", data = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token) });

            }
            catch (Exception ex)
            {
                return Ok(new Models.ApiResponse { status = 0, message = ex.Message, data = "" });
            }
        }

        // /api/token/delete
        public IActionResult Delete(string token)
        {
            //code: 加入黑名单，使其无效

            return Ok(new Models.ApiResponse { status = 1, message = "OK", data = "" });
        }
    }
}