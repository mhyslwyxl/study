using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglerDemo.Controllers
{
    [Route("api/count")]
    public class CountController : Controller
    {
        private readonly IHubContext<CountHub> _counthub;

        public CountController(IHubContext<CountHub> counthub)
        {
            _counthub = counthub;
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _counthub.Clients.All.SendAsync("somefunc", new { random = "abcd" });
            return Accepted(1);
        }
    }
}
