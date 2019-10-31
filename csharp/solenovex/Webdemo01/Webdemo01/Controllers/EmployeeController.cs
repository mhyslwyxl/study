using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webdemo01.service;
using Webdemo01.Models;

namespace Webdemo01.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeservice)
        {
            _departmentService = departmentService;
            _employeeservice = employeeservice;
        }

        public async Task<IActionResult> Index(int departentId)
        {
            var department = await _departmentService.GetById(departentId);
            ViewBag.Title = $"Employees of {department.Name}";
            ViewBag.DepartmentId = departentId;
            var employees = await _employeeservice.GetByDepartmentId(departentId);
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Title";
            return View(new Employee { DepartmentId = departmentId });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeservice.Add(model);
            }

            return RedirectToAction(nameof(Index), new { departmentId = model.DepartmentId });
        }

        [HttpPost]
        public async Task<IActionResult> fire(int employeeId)
        {
            var employee = await _employeeservice.Fire(employeeId);

            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }
    }
}