using BusinessObjects.Commons;
using System;
using System.Collections.Generic;

namespace BusinessObjects.Entities;

public partial class UnderlyingDisease : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PatientUnderlyingDisease> PatientUnderlyingDiseases { get; set; } = new List<PatientUnderlyingDisease>();
}
