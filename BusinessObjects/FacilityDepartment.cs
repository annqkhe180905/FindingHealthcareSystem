using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class FacilityDepartment
{
    public Guid Id { get; set; }

    public Guid? FacilityId { get; set; }

    public Guid? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Facility? Facility { get; set; }
}
