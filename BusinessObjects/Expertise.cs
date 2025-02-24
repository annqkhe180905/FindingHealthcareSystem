using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Expertise
{
    public Guid ExpertiseId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Professional> Professionals { get; set; } = new List<Professional>();
}
