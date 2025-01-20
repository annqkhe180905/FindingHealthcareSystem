using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class MedicalRecord
{
    public Guid MedicalRecordId { get; set; }

    public Guid? AppointmentId { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Symptoms { get; set; }

    public string? Diagnosis { get; set; }

    public string? Prescription { get; set; }

    public string? Note { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}
