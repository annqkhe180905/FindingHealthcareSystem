using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public string? PaymentStatus { get; set; }

    public decimal? Price { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
