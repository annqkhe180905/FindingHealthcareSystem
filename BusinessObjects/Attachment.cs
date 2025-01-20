using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Attachment
{
    public Guid Id { get; set; }

    public Guid? MedicalRecordId { get; set; }

    public string? Url { get; set; }

    public virtual MedicalRecord? MedicalRecord { get; set; }
}
