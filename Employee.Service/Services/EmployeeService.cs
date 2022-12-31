using Employee.Domain.Common;
using Employee.Domain.Common.Enum;
using Employee.Domain.Dtos;
using Employee.Domain.IRepository;
using Employee.Domain.IService;
using Employee.Domain.Model;
using Employee.Service.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }



        public async Task<Employees> Add(Employees entity)
        {
            Employees Employee = await _EmployeeRepository.Add(entity);
            _unitOfWork.Save();
            return Employee;
        }

        public async Task<ResponseResult<Domain.Model.Employees>> Add(EmploeeDto entity)
        {
            ResponseResult<Domain.Model.Employees> responseResult = new ResponseResult<Domain.Model.Employees>();

            var userNameExists = _userRepository.GetByUserName(entity.UserName);
            if (userNameExists != null)
            {
                responseResult.ErrorMessage = ErrorMessage.UserNameAlreadyExists;
                return responseResult;
            }
            var salt = HelperService.GenrateSalt();
            User user = new User()
            {
                UserName = entity.UserName,
                Password = "Test@1234".GeneratePassowrd(salt),
                CreationDate = DateTime.Now,
                Role = RoleEnum.Employee,
                Salt = salt
            };
            // await _userRepository.Add(user);
            Employees employee = new Employees()
            {
                UserId = user.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Salary = entity.Salary,
                StartDate = entity.StartDate,
                User = user
            };
            await _EmployeeRepository.Add(employee);
            _unitOfWork.Save();
            responseResult.SetSuccess(employee);
            return responseResult;
        }

        public async Task<Employees> FirstOrDefault(Expression<Func<Employees, bool>> predicate = null)
        {
            Employees Employee = await _EmployeeRepository.FirstOrDefault(predicate);
            return Employee;
        }

        public async Task<List<Employees>> GetAll(Expression<Func<Employees, bool>> predicate = null)
        {
            List<Employees> employees = _EmployeeRepository.GetAll(predicate).ToList();
            return employees;
        }

        public List<Employees> GetAll(string search)
        {
            List<Employees> employees =  _EmployeeRepository.GetAll(x=> x.FirstName.Contains(search) || x.LastName.Contains(search) || search == null || x.User.UserName.Contains(search) , x => x.Include(x => x.User)).ToList();
            return employees;
        }

        public async Task<Employees> GetById(int Id)
        {
            Employees Employee = await  _EmployeeRepository.FirstOrDefault(x => x.Id  == Id , x =>  x.Include(x => x.User) );
            return Employee;
        }



        public void Remove(Employees entity)
        {
            _EmployeeRepository.Remove(entity);
            _unitOfWork.Save();

        }

        public void Remove(int Id)
        {
            _EmployeeRepository.Remove(Id);
            _unitOfWork.Save();
        }

        public Employees Update(Employees entity)
        {
            _EmployeeRepository.Update(entity);
            _unitOfWork.Save();
            return entity;
        }

        public async Task<ResponseResult<Employees>> Update(EmploeeDto entityDto)
        {
            ResponseResult<Employees> responseResult = new ResponseResult<Employees>();

            var employeeDb =  _EmployeeRepository.GetById((int)entityDto.Id);
            User user = _userRepository.GetById(employeeDb.UserId);
            employeeDb.FirstName = entityDto.FirstName;
            employeeDb.LastName = entityDto.LastName;
            employeeDb.StartDate = entityDto.StartDate;
            employeeDb.Salary = entityDto.Salary;
            _EmployeeRepository.Update(employeeDb);
            _unitOfWork.Save();
            responseResult.SetSuccess(employeeDb);
            return responseResult;
        }


    }
}
