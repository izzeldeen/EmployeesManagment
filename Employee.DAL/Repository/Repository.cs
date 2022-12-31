using Employee.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StoreContext _context;
        private readonly DbSet<T> dbSet;
        public Repository(StoreContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await  dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if(include != null)
            {
                query = (IQueryable<T>)include(query);
            }

            if(predicate != null)
            {
             return   await query.FirstOrDefaultAsync(predicate);
            }
            return await query.FirstOrDefaultAsync();
        }

        public  List<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if (include != null)
            {
                query = (IQueryable<T>)include(query);
            }

            if (predicate != null)
            {
                return query.Where(predicate).ToList();
            }

            return query.ToList();
        }

        public T GetById(int Id)
        {
            return  dbSet.Find(Id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Remove(int Id)
        {
            T entity =  dbSet.Find(Id);
            dbSet.Remove(entity);
        }

        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }
    }
}
