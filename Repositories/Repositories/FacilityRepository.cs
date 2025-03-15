using Repositories.Interfaces;
using DataAccessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Entities;

namespace Repositories.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly IFacilityDao _facilityDao;

        public FacilityRepository(IFacilityDao facilityDao)
        {
            _facilityDao = facilityDao;
        }

        public async Task<Facility> GetByIdWithRelationsAsync(int id)
        {
            return await _facilityDao.GetByIdWithRelationsAsync(id);
        }

        public async Task<Facility> CreateAsync(Facility facility)
        {
            return await _facilityDao.CreateAsync(facility);
        }

        public async Task CreateFacilityDepartmentsAsync(List<FacilityDepartment> facilityDepartments)
        {
            await _facilityDao.CreateFacilityDepartmentsAsync(facilityDepartments);
        }

        public async Task UpdateFacilityDepartmentsAsync(int facilityId, List<int> departmentIds)
        {
            await _facilityDao.UpdateFacilityDepartmentsAsync(facilityId, departmentIds);
        }
    }
}
