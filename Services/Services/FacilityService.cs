using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using BusinessObjects.DTOs.Facility;
using BusinessObjects.Enums;

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

        public async Task<IEnumerable<FacilityDto>> SearchFacilities(string? name, string? province, string? operationDay, string? district, string? city, bool isAdmin, int? typeId)
        {
            var filters = new Dictionary<string, object?>();

            if (!string.IsNullOrEmpty(name)) filters["Name"] = name;
            if (!string.IsNullOrEmpty(province)) filters["Province"] = province;
            if (!string.IsNullOrEmpty(operationDay)) filters["OperationDay"] = operationDay;
            if (!string.IsNullOrEmpty(district)) filters["District"] = district;
            if (!string.IsNullOrEmpty(city)) filters["City"] = city;
            if(isAdmin == false) filters["Status"] = FacilityStatus.Active;
            if (typeId.HasValue) filters["TypeId"] = typeId;

            var includes = new List<string> {"FacilityType"};

            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facilities = await facRepo.SearchAsync(filters);
            return _mapper.Map<List<FacilityDto>>(facilities);
        }

        public async Task<FacilityDto> Create(FacilityDto facilityDto)
        {
            //validation
            var requiredFields = new Dictionary<string, object>
            {
                { "Facility type", facilityDto.TypeId },
                { "Facility name", facilityDto.Name },
                { "Facility operation day", facilityDto.OperationDay },
                { "Facility province", facilityDto.Province },
                { "Facility district", facilityDto.District },
                { "Facility city", facilityDto.City },
                { "Facility address", facilityDto.Address }
            };

            foreach (var field in requiredFields)
            {
                if (field.Value == null || (field.Value is string str && string.IsNullOrEmpty(str)))
                {
                    throw new Exception($"{field.Key} is required");
                }
            }

            facilityDto.Status = FacilityStatus.Inactive;
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = _mapper.Map<Facility>(facilityDto);
            facility.CreatedAt = DateTime.UtcNow.AddHours(7);
            facility.IsDeleted = true;
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
            var requiredFields = new Dictionary<string, object>
            {
                { "Facility type", facilityDto.TypeId },
                { "Facility name", facilityDto.Name },
                { "Facility operation day", facilityDto.OperationDay },
                { "Facility province", facilityDto.Province },
                { "Facility district", facilityDto.District },
                { "Facility city", facilityDto.City },
                { "Facility address", facilityDto.Address },
                { "Facility description", facilityDto.Description },
                { "Facility status", facilityDto.Status }
            };

            foreach (var field in requiredFields)
            {
                if (field.Value == null || (field.Value is string str && string.IsNullOrEmpty(str)))
                {
                    throw new Exception($"{field.Key} is required");
                }
            }
            var facMap = _mapper.Map<Facility>(facilityDto);
            facMap.UpdatedAt = DateTime.UtcNow.AddHours(7);
            facRepo.Update(facMap);
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

        public async Task<FacilityDto> DeleteAsync(int id)
        {
            var facRepo = _unitOfWork.GetRepository<Facility>();
            var facility = await facRepo.GetByIdAsync(id);
            if (facility == null)
            {
                throw new Exception("Facility not found");
            }
            facility.Status = FacilityStatus.Inactive;
            facility.UpdatedAt = DateTime.UtcNow.AddHours(7);
            facility.IsDeleted = true;
            facRepo.Update(facility);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<FacilityDto>(facility);
        }
    }
}
