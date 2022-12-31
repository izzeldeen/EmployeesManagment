using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
         T GetById(int Id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate = null , Func<IQueryable<T> , IIncludableQueryable<T, object>> include = null);
        Task<T> Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void Remove(int Id);
    }
    
}
