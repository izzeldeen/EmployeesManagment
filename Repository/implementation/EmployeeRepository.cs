using Domain.Entities;
using Domain.IRepository;
using Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.implementation
{
    public class EmployeeRepository : Repositroy<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(StoreContext context) : base(context)
        {
        }

    }
}
