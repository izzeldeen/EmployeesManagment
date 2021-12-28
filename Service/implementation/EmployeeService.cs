using Domain.CountryDto;
using Domain.Dto;
using Domain.Entities;
using Domain.IRepository;
using Domain.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Add(Employee employee)
        {
            try
            {
                _unitOfWork.Employee.Add(employee);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
                
        }

       

        public Employee Get(int id)
        {
            return _unitOfWork.Employee.Get(id);
        }

        public  IEnumerable<EmployeeSimpleDto> GetAll()
        {
            IEnumerable<Employee> employees =  _unitOfWork.Employee.GetAll();
            IEnumerable<EmployeeSimpleDto> employeeSimpleDto = employees.Select(x => new EmployeeSimpleDto { FullName = x.FullName , Id = x.Id });
            return employeeSimpleDto;
        }

        public void Remove(Employee entity)
        {
            _unitOfWork.Employee.Remove(entity);
        }

        public bool Remove(int id)
        {
            try
            {
                _unitOfWork.Employee.Remove(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void RemoveRange(IEnumerable<Employee> entity)
        {
            _unitOfWork.Employee.RemoveRange(entity);
        }

        public bool Update(Employee entity)
        {
            try
            {
                _unitOfWork.Employee.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerable<Employee> IService<Employee>.GetAll()
        {
            return _unitOfWork.Employee.GetAll();
        }
    }
}
