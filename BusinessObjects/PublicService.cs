using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class PublicService
{
    public Guid ServiceId { get; set; }

    public Guid? FacilityId { get; set; }

    public virtual Facility? Facility { get; set; }

    public virtual Service Service { get; set; } = null!;
}
