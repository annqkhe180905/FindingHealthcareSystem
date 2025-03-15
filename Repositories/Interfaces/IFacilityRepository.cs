using BusinessObjects.Entities;

namespace Repositories.Interfaces
{
    public interface IFacilityRepository
    {
        Task<Facility> GetByIdWithRelationsAsync(int id);

        Task<Facility> CreateAsync(Facility facility);

        Task CreateFacilityDepartmentsAsync(List<FacilityDepartment> facilityDepartments);

        Task UpdateFacilityDepartmentsAsync(int facilityId, List<int> departmentIds);
    }
}