using Employee.Domain.Dtos;
using Employee.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.IService
{
    public interface IUserService : IService<User>
    {
        Task<ResponseResult<string>> Register(RegisterUserDto userDto);
        Task<ResponseResult<string>> Login(LoginDto userDto);
    }
}
