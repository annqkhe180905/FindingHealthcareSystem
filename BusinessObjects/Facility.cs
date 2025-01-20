using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Facility
{
    public Guid FacilityId { get; set; }

    public Guid? TypeId { get; set; }

    public string? Name { get; set; }

    public DateOnly? OperationDay { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Commune { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<FacilityDepartment> FacilityDepartments { get; set; } = new List<FacilityDepartment>();

    public virtual ICollection<PublicService> PublicServices { get; set; } = new List<PublicService>();

    public virtual FacilityType? Type { get; set; }
}
