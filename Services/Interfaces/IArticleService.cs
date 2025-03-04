using BusinessObjects.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleReadDTO>> GetAllNewsArticles();
        Task<ArticleReadDTO> GetNewsArticleByID(int id);
        Task<ArticleCreateDTO> CreateNewsArtiles(ArticleCreateDTO newsArticleDTO);
        Task<ArticleUpdateDTO> UpdateNewsArticleByID(ArticleUpdateDTO newsArticleDTO,int id);
        Task<bool> DeleteNewsArticles(int id);
    }
}
