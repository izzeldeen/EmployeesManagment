using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
     public  interface IService<T> where T : class 
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        bool Update(T entity);

        bool Add(T entity);

        void Remove(T entity);

        bool Remove(int id);

        void RemoveRange(IEnumerable<T> entity);

    }
}
