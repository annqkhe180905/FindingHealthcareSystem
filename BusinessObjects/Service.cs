using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Service
{
    public Guid ServiceId { get; set; }

    public decimal? Price { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual PrivateService? PrivateService { get; set; }

    public virtual PublicService? PublicService { get; set; }
}
