using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class ProfessionalSpecialty
{
    public Guid Id { get; set; }

    public Guid? ProfessionalId { get; set; }

    public Guid? SpecialtyId { get; set; }

    public virtual Professional? Professional { get; set; }

    public virtual Specialty? Specialty { get; set; }
}
