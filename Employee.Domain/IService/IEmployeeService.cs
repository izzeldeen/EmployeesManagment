using Employee.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.IService
{
    public interface IEmployeeService : IService<Employee.Domain.Model.Employees>
    {
        Task<ResponseResult<Domain.Model.Employees>> Add(EmploeeDto entity);
        Task<ResponseResult<Domain.Model.Employees>> Update(EmploeeDto entity);
        List<Domain.Model.Employees> GetAll(string search);

    }
}
