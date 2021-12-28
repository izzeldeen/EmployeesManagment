using Domain.IRepository;
using Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _db;
        public UnitOfWork(StoreContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
            Employee = new EmployeeRepository(_db);
        }

        public ICountryRepository Country { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
