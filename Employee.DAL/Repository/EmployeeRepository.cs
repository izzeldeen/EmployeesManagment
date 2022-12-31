using Employee.Domain.IRepository;
using Employee.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Repository
{
    public  class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(StoreContext context) : base(context)
        {
          
        }
    }
}
