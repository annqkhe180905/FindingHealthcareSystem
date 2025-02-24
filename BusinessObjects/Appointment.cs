using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Appointment
{
    public Guid AppointmentId { get; set; }

    public Guid? PatientId { get; set; }

    public Guid? ProfessionalId { get; set; }

    public Guid? ServiceId { get; set; }

    public string? Status { get; set; }

    public Guid? PaymentId { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual Patient? Patient { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Professional? Professional { get; set; }

    public virtual Service? Service { get; set; }
}
