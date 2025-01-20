using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Article
{
    public Guid ArticleId { get; set; }

    public Guid? CategoryId { get; set; }

    public string? Title { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? Content { get; set; }

    public virtual Category? Category { get; set; }
}
