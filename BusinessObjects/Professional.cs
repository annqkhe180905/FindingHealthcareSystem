using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Professional
{
    public Guid ProfessionalId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ExpertiseId { get; set; }

    public string? Province { get; set; }

    public string? District { get; set; }

    public string? Commune { get; set; }

    public string? Address { get; set; }

    public string? Degree { get; set; }

    public string? Experience { get; set; }

    public string? WorkingHours { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Expertise? Expertise { get; set; }

    public virtual ICollection<PrivateService> PrivateServices { get; set; } = new List<PrivateService>();

    public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpecialty>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User? User { get; set; }
}
