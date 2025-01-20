using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Specialty
{
    public Guid SpecialtyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpecialty>();
}
