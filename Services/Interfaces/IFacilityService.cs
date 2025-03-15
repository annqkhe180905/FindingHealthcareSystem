using BusinessObjects.DTOs.Facility;

namespace Services.Interfaces
{
    public interface IFacilityService
    {
        Task<List<FacilityDto>> GetAllFacilities();
        Task<IEnumerable<FacilityDto>> SearchFacilities(string? name, string? province, string? operationDay, string? district, string? city, bool isAdmin, int? typeId);
        Task<FacilityDto> Create(FacilityDto facilityDto);
        Task<FacilityDto> Update(int id, FacilityDto facilityDto);
        Task<FacilityDto> GetById(int id);
        Task<FacilityDto> DeleteAsync(int id);
    }
}