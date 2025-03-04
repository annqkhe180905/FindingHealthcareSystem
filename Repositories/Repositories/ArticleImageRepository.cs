using BusinessObjects.Commons;
using BusinessObjects.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ArticleImageRepository : IArticleImageRepository
    {
        public Task AddAsync(ArticleImage entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<ArticleImage> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleImage>> FindAllAsync(Expression<Func<ArticleImage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleImage> FindAsync(Expression<Func<ArticleImage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleImage>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<ArticleImage>> GetPagedListAsync(Expression<Func<ArticleImage, bool>> filter, int pageIndex, int pageSize, Func<IQueryable<ArticleImage>, IOrderedQueryable<ArticleImage>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Remove(ArticleImage entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ArticleImage> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ArticleImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
