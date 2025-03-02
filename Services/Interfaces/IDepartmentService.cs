using BusinessObjects.DTOs.Department;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
    }
}
