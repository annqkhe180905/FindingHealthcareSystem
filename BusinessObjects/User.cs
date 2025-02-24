using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class User
{
    public Guid UserId { get; set; }

    public string? Role { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Professional? Professional { get; set; }
}
