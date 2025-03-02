using BusinessObjects.DTOs.Category;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Articles
{
    public class NewsArticleDTO
    {
        public Guid ArticleId { get; set; }

        public Guid? CategoryId { get; set; }

        public string? Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? Content { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }
}
