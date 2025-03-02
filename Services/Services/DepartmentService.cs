using AutoMapper;
using BusinessObjects.Dtos.User;
using BusinessObjects.DTOs.Department;
using BusinessObjects.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var departmentRepo = _unitOfWork.GetRepository<Department>();
            var departments = await departmentRepo.GetAllAsync();
            if (departments == null || !departments.Any())
            {
                return new List<DepartmentDto>();
            }
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
