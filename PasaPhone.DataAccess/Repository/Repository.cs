using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasaPhone.DataAccess.Data;
using PasaPhone.DataAccess.Repository.IRepository;

namespace PasaPhone.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>(); // _context.Phones == dbSet
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public Task<T?> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefaultAsync();
        }

        //public IEnumerable<T> GetAll()
        //{
        //    IQueryable<T> query = dbSet;
        //    return query.ToList();
        //}

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public bool IsItemExists(Expression<Func<T, bool>> doesExist)
        {
            return dbSet.Any(doesExist);
        }
    }
}
