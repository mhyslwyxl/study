using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webdemo01.Controllers
{
    public class DesignPatternController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adapter()
        {
            return View();
        }

    }
}