using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class FacilityType
{
    public Guid TypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
