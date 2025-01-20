﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Patient
{
    public Guid PatientId { get; set; }

    public Guid? UserId { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<PatientUnderlyingDisease> PatientUnderlyingDiseases { get; set; } = new List<PatientUnderlyingDisease>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User? User { get; set; }
}
