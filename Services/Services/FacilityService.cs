using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using BusinessObjects.DTOs.Facility;

namespace Services.Services
{
    public class FacilityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacilityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FacilityDto>> GetAllFacilities()
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facilities = await facRepo.GetAllAsync();
            if (facilities == null || !facilities.Any())
            {
                return new List<FacilityDto>();
            }
            return _mapper.Map<List<FacilityDto>>(facilities);
        }

        public async Task<FacilityDto> Create(FacilityDto facilityDto)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = _mapper.Map<Facility>(facilityDto);
            await facRepo.AddAsync(facility);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<FacilityDto> Update(int id, FacilityDto facilityDto)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            facility.Name = facilityDto.Name;
            facility.Description = facilityDto.Description;
            facRepo.Update(facility);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(facility);
        }

        public async Task<FacilityDto> GetById(int id)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            return _mapper.Map<FacilityDto>(facility);
        }
    }
}
