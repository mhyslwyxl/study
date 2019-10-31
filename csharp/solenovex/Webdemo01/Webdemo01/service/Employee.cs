using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo01.Models;

namespace Webdemo01.service
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "zhang",
                LastName = "san",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 2,
                FirstName = "li",
                LastName = "si",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 3,
                FirstName = "wang",
                LastName = "wu",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 4,
                FirstName = "liu",
                LastName = "qi",
                Gender = Gender.男
            });
        }

        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == id);
                if (employee == null)
                    return null;
                employee.Fired = true;
                return employee;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId));
        }
    }
}
