using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Services
{
    public class UserService
    {
        public LoginResult Login(string account, string pwd)
        {
            if (account.ToLower() == "admin")
                return new LoginResult { Code = 200, Message = "", Body = new LoginBody { Id = 1, NickName = "张三" } };
            return new LoginResult { Code = 401, Message = "Account Or Pwd Fail!!!" };

        }
    }

    public class LoginResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public LoginBody Body { get; set; }


    }

    public class LoginBody
    {
        public int Id { get; set; }
        public string NickName { get; set; }
    }
}
