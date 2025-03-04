using DataAccessObjects.DAOs;
using DataAccessObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repositories;
using DataAccessObjects.Interfaces;
using BusinessObjects.Entities;

namespace Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FindingHealthcareSystemContext _context;
        private readonly Dictionary<Type, object> _repositories;

        private readonly IArticleRepository ArticleRepository;
        private readonly IArticleImageRepository ArticleImageRepository;
        public UnitOfWork(FindingHealthcareSystemContext context,IArticleRepository articleRepository,IArticleImageRepository articleImageRepository)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            ArticleRepository = articleRepository; 
            ArticleImageRepository = articleImageRepository;
        }


        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var dao = new GenericDAO<T>(_context);
                var repository = new GenericRepository<T>(dao);
                _repositories[typeof(T)] = repository;
            }

            return (IGenericRepository<T>)_repositories[typeof(T)];
        }


        public IArticleRepository _articleRepository => ArticleRepository;

        public IArticleImageRepository _articleImageRepository => ArticleImageRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
