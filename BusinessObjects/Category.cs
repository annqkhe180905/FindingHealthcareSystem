using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
