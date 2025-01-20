using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class UnderlyingDisease
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PatientUnderlyingDisease> PatientUnderlyingDiseases { get; set; } = new List<PatientUnderlyingDisease>();
}
