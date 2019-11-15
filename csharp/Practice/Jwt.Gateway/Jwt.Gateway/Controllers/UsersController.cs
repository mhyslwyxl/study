using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UsersController : ApiBase
    {
        /* 
         * 1.要访问访问该控制器提供的接口请先通过"/api/token/get"获取token
         * 2.访问该控制器提供的接口http请求头必须具有值为"Bearer+空格+token"的Authorization键，格式参考：
         *   "Authorization"="Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiQXBwIiwiYXBwS2V5IjoibXlLZXkiLCJleHAiOjE1NTE3ODc2MDMsImlzcyI6IkdhdGV3YXkiLCJhdWQiOiJhdWRpZW5jZSJ9.gQ9_Q7HUT31oFyfl533T-bNO5IWD2drl0NmD1JwQkMI"
        */

        /// <summary>
        /// 临时用户测试数据，实际项目中应该来自数据库等媒介
        /// </summary>
        static List<Models.User> _Users = null;
        static object _Lock = new object();
        public UsersController()
        {
            if (_Users == null)
            {
                lock (_Lock)
                {
                    if (_Users == null)
                    {
                        _Users = new List<Models.User>();
                        var now = DateTime.Now;
                        for (var i = 0; i < 10; i++)
                        {
                            var num = i + 1;
                            _Users.Add(new Models.User { UserId = num, UserName = "name" + num, UserPassword = "pwd" + num, UserJoinTime = now });
                        }
                    }
                }
            }
        }

        // /api/users/detail
        [ApiActionFilter("用户明细")]
        public IActionResult Detail(long userId)
        {
            /*
            //获取appKey(在ApiBase中写入)
            var appKey = CurrentAppKey;
            //获取使用的权限(在ApiActionAuthorizeAttribute中写入)
            var permissions = HttpContext.Items["Permissions"];
            */

            var user = _Users.Find(o => o.UserId == userId);
            if (user == null)
            {
                throw new Exception("用户不存在");
            }

            return Ok(new Models.ApiResponse { data = user, status = 1, message = "OK" });
        }

        // /api/users/list
        [ApiActionFilter("用户列表")]
        public IActionResult List(int page, int size)
        {
            page = page < 1 ? 1 : page;
            size = size < 1 ? 1 : size;
            var total = _Users.Count();
            var pages = total % size == 0 ? total / size : ((long)Math.Floor((double)total / size + 1));
            if (page > pages)
            {
                return Ok(new Models.ApiResponse { data = new List<Models.User>(), status = 1, message = "OK", total = total });
            }
            var li = new List<Models.User>();
            var startIndex = page * size - size;
            var endIndex = startIndex + size - 1;
            if (endIndex > total - 1)
            {
                endIndex = total - 1;
            }
            for (; startIndex <= endIndex; startIndex++)
            {
                li.Add(_Users[startIndex]);
            }
            return Ok(new Models.ApiResponse { data = li, status = 1, message = "OK", total = total });
        }

        // /api/users/add
        [ApiActionFilter("用户录入")]
        public IActionResult Add()
        {
            return Ok(new Models.ApiResponse { status = 1, message = "OK" });
        }

        // /api/users/update
        [ApiActionFilter(new string[] { "用户修改", "用户录入", "用户删除" }, ApiActionFilterAttributeOption.AND)]
        public IActionResult Update()
        {
            return Ok(new Models.ApiResponse { status = 1, message = "OK" });
        }

        // /api/users/delete
        [ApiActionFilter("用户删除")]
        public IActionResult Delete()
        {
            return Ok(new Models.ApiResponse { status = 1, message = "OK" });
        }
    }
}