using LMS.DAL.Data;
using LMS.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LMSDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository()
        {
            _dbContext = new();
            _dbSet = _dbContext.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
