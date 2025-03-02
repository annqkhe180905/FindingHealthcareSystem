using AutoMapper;
using BusinessObjects.DTOs.Articles;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<NewsArticleDTO> CreateNewsArtiles(NewsArticleDTO newsArticleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteNewsArticles(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsArticleDTO>> GetAllNewsArticles()
        {
            var result = _unitOfWork.ArticleRepository().GetAllNewsArticles();
        }

        public Task<NewsArticleDTO> GetNewsArticleByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NewsArticleDTO> UpdateNewsArticleByID(NewsArticleDTO newsArticleDTO)
        {
            throw new NotImplementedException();
        }
    }
}
