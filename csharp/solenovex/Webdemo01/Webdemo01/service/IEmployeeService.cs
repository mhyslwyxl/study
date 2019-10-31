using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo01.Models;

namespace Webdemo01.service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> Fire(int id);
        Task Add(Employee employee);
    }
}
