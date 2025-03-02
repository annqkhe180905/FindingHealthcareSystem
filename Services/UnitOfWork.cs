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
        private readonly Dictionary<Type, object> _daos;
        private IArticleRepository _articleRepository;



        public UnitOfWork(FindingHealthcareSystemContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _daos = new Dictionary<Type, object>();
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

        // ✅ Tạo Generic DAO
        public IGenericDAO<T> GetDAO<T>() where T : class
        {
            if (!_daos.ContainsKey(typeof(T)))
            {
                var dao = new GenericDAO<T>(_context);
                _daos[typeof(T)] = dao;
            }
            return (IGenericDAO<T>)_daos[typeof(T)];
        }

        public IArticleRepository ArticleRepository =>_articleRepository ??= new ArticleRepository(GetDAO<Article>());
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
