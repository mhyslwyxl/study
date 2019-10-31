using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webdemo01.service;
using Webdemo01.Models;

namespace Webdemo01.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentservice;

        public DepartmentController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Title";
            var departments = await _departmentservice.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Title";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentservice.Add(model);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}