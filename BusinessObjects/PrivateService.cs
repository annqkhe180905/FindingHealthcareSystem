using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class PrivateService
{
    public Guid ServiceId { get; set; }

    public Guid? ProfessionalId { get; set; }

    public virtual Professional? Professional { get; set; }

    public virtual Service Service { get; set; } = null!;
}
