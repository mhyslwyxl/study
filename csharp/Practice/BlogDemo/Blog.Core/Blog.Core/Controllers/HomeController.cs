using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace Blog.Core.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<string>> get()
        {
            return new string[] { "Value1", "Value2" };
        }
    }
}