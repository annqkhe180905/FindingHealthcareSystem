using BusinessObjects.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; } // ID của danh mục
        public string? Name { get; set; } // Tên danh mục
        public string? Description { get; set; } // Mô tả danh mục
        public List<ArticleCreateDTO>? Articles { get; set; } // Danh sách bài viết thuộc danh mục
    }
}
