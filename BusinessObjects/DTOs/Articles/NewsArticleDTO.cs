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
        public int Id { get; set; } // ID của bài viết
        public int? CategoryId { get; set; } // ID của chuyên mục
        public string? CategoryName { get; set; } // Tên chuyên mục (để hiển thị)
        public string? Title { get; set; } // Tiêu đề bài viết
        public string? Content { get; set; } // Nội dung bài viết
        public DateTime? CreatedAt { get; set; } // Ngày tạo bài viết
        public int? CreatedById { get; set; } // ID của người tạo bài viết
        public string? CreatedByName { get; set; } // Tên người tạo (để hiển thị)
    }
}
