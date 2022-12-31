using Employee.Domain.Dtos;
using Employee.Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(EmploeeDto employee)
        {
            var result = await _employeeService.Add(employee);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
           _employeeService.Remove(Id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmploeeDto employee)
        {
           var result =  await _employeeService.Update(employee);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]string? search)
        {
            var employees =  _employeeService.GetAll(search);
            return Ok(employees);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var employee = await _employeeService.GetById(Id);
            return Ok(employee);
        }
    }
}
