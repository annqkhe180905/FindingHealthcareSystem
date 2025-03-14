using BusinessObjects.DTOs.Facility;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFacilityTypeService
    {
        Task<List<FacilityTypeDto>> GetAllFacilityTypes();
        Task<IEnumerable<FacilityDto>> SearchFacilities(string? name, string? province, string? operationDay, string? district, string? city);
        Task<FacilityDto> Create(FacilityDto facilityDto);
        Task<FacilityDto> Update(int id, FacilityDto facilityDto);
        Task<FacilityDto> GetById(int id);
        Task<FacilityDto> DeleteAsync(int id);
    }
}
