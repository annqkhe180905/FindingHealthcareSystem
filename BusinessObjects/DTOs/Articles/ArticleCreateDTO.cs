using BusinessObjects.DTOs.Category;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Articles
{
    public class ArticleCreateDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatedById { get; set; } // User who creates the article
        public List<string> ImageUrls { get; set; } = new List<string>(); // Image URLs for the article
    }
}
