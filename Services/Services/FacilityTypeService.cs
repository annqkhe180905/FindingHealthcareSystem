using AutoMapper;
using BusinessObjects.DTOs.Department;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FacilityTypeService : IFacilityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacilityTypeService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<FacilityTypeDto>> GetAllFacilityTypes()
        {
            var facRepo = _unitOfWork.GetRepository<FacilityType>();
            var facilities = await facRepo.GetAllAsync();
            if (facilities == null || !facilities.Any())
            {
                return new List<FacilityTypeDto>();
            }
            return _mapper.Map<List<FacilityTypeDto>>(facilities);
        }
    }
}
