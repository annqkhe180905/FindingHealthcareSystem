using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Facility
{
    public class FacilityDto
    {
        public int? Id { get; set; }
        public int? TypeId { get; set; }

        public string? Name { get; set; }

        public DateOnly? OperationDay { get; set; }

        public string? Province { get; set; }

        public string? District { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }

        public FacilityStatus Status { get; set; }

        public IEnumerable<FacilityDepartmentDto> FacilityDepartments { get; set; } = new List<FacilityDepartmentDto>();
    }
}
