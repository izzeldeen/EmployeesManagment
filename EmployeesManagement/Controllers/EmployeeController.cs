using AutoMapper;
using Domain.CountryDto;
using Domain.Dto;
using Domain.Entities;
using Domain.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
      
        public EmployeeController(IEmployeeService employeeService , IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


        [HttpGet("{Id}")]
        public ActionResult<EmployeeDetailsDto> GetById(int Id)
        {
          Employee employee =   _employeeService.Get(Id);
            return Ok( _mapper.Map<Employee, EmployeeDetailsDto>(employee));
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeSimpleDto>> GetAll()
        {
            return Ok(_employeeService.GetAll());
        }
       

        [HttpPost]
        public ActionResult<Employee> Post(EmployeeDetailsDto employeeDetailsDto)
        {
           Employee employee = _mapper.Map<EmployeeDetailsDto, Employee>(employeeDetailsDto);
           return  _employeeService.Add(employee) ? Ok(employee) : BadRequest();
           
        }

        [HttpPut]
        public ActionResult<Employee> Update(EmployeeDetailsDto employeeDetailsDto)
        {
            Employee employee = _mapper.Map<EmployeeDetailsDto, Employee>(employeeDetailsDto);
            return _employeeService.Update(employee) ? Ok(employee) : BadRequest();
            
        }

        [HttpDelete("{Id}")]
        public ActionResult<Employee> Delete(int Id)
        {
           return  _employeeService.Remove(Id) ? Ok() : BadRequest();
        }

       


    }
}
