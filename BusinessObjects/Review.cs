using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Review
{
    public Guid ReviewId { get; set; }

    public Guid? ProfessionalId { get; set; }

    public Guid? PatientId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Date { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Professional? Professional { get; set; }
}
