using BusinessObjects.Entities;
using DataAccessObjects.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly IGenericDAO<Article> _articleDAO;
        public ArticleRepository(IGenericDAO<Article> dao) : base(dao)
        {
            _articleDAO = dao;
        }

        public Task<Article> GetAllArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
