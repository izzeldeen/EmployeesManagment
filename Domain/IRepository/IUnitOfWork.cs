using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
   public  interface IUnitOfWork : IDisposable
    {
        ICountryRepository Country { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
