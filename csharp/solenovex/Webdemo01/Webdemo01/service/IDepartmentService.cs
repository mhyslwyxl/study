using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo01.Models;

namespace Webdemo01.service
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<CompanySummary> GetCompanySummary();
        Task Add(Department department);
    }
}
