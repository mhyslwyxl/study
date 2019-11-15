using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOPTest.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOPTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        readonly IUserservice _user;

        public DemoController(IUserservice user)
        {
            _user = user;
        }

        [HttpGet]
        public string Get()
        {
            return _user.SayHello();
        }
    }
}