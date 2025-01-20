using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class PatientUnderlyingDisease
{
    public Guid Id { get; set; }

    public Guid? UnderlyingDiseaseId { get; set; }

    public Guid? PatientId { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual UnderlyingDisease? UnderlyingDisease { get; set; }
}
