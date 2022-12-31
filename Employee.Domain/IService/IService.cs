using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.IService
{
    public interface IService<T>
    { 
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> GetById(int Id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate = null);
        Task<T> Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void Remove(int Id);
    }
}
