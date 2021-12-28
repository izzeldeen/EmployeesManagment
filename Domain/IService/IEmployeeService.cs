using Domain.CountryDto;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
     public  interface IEmployeeService : IService<Employee>
    {
        IEnumerable<EmployeeSimpleDto> GetAll();
       
    }
}
