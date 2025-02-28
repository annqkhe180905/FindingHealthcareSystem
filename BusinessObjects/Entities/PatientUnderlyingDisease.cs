using BusinessObjects.Commons;
using System;
using System.Collections.Generic;

namespace BusinessObjects.Entities;

public partial class PatientUnderlyingDisease : BaseEntity
{
    public int? UnderlyingDiseaseId { get; set; }

    public int? PatientId { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual UnderlyingDisease? UnderlyingDisease { get; set; }
}
