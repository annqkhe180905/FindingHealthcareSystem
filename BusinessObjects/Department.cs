using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Department
{
    public Guid DepartmentId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<FacilityDepartment> FacilityDepartments { get; set; } = new List<FacilityDepartment>();
}
