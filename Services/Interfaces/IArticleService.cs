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
        Task<IEnumerable<NewsArticleDTO>> GetAllNewsArticles();
        Task<NewsArticleDTO> GetNewsArticleByID(int id);
        Task<NewsArticleDTO> CreateNewsArtiles(NewsArticleDTO newsArticleDTO);
        Task<NewsArticleDTO> UpdateNewsArticleByID(NewsArticleDTO newsArticleDTO);
        Task<bool> DeleteNewsArticles(int id);
    }
}
