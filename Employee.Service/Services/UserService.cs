using Employee.Domain.Common;
using Employee.Domain.Common.Enum;
using Employee.Domain.Dtos;
using Employee.Domain.IRepository;
using Employee.Domain.IService;
using Employee.Domain.Model;
using Employee.Service.Common;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public UserService(IUserRepository userRepository , IUnitOfWork unitOfWork , IConfiguration config)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<ResponseResult<string>> Register(RegisterUserDto userDto)
        {
            ResponseResult<string> reponseResult = new ResponseResult<string>();

            
            User userDb = _userRepository.GetByUserName(userDto.UserName);
            if(userDb != null)
            {
                reponseResult.ErrorMessage = ErrorMessage.UserNameAlreadyExists;
                return reponseResult;
            }
            var salt = HelperService.GenrateSalt();
            User user = new User()
            {
                UserName = userDto.UserName,
                Password = userDb.Password.GeneratePassowrd(salt),
                CreationDate = DateTime.Now,
                Role = RoleEnum.Employee,
                Salt = salt
            };
            await _userRepository.Add(user);
            _unitOfWork.Save();
            reponseResult.SetSuccess("Register Successfly");
            return reponseResult;
        }

        public async Task<User> Add(User entity)
        {
            User user = await  _userRepository.Add(entity);
            _unitOfWork.Save();
            return user;
        }

        public async Task<User> FirstOrDefault(Expression<Func<User, bool>> predicate = null)
        {
            User user = await _userRepository.FirstOrDefault(predicate);
            return user;
        }

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> predicate = null)
        {
            List<User> users =  _userRepository.GetAll(predicate);
            return users;
        }

        public async Task<User> GetById(int Id)
        {
            User user = await  _userRepository.FirstOrDefault(x => x.Id == Id);
            return user;
        }

      

        public void Remove(User entity)
        {
           _userRepository.Remove(entity);
            _unitOfWork.Save();
            
        }

        public void Remove(int Id)
        {
            _userRepository.Remove(Id);
            _unitOfWork.Save();
        }

        public User Update(User entity)
        {
            _userRepository.Update(entity);
            _unitOfWork.Save();
            return entity;
        }

        private string GeneratePassowrd(string password , byte[] salt)
        {
            
            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return passwordHash;
        }

        public async Task<ResponseResult<string>> Login(LoginDto userDto)
        {
            ResponseResult<string> reponseResult = new ResponseResult<string>();
            User user = _userRepository.GetByUserName(userDto.UserName);

            if(user == null || user.Password != GeneratePassowrd(userDto.Password , user.Salt))
            {
                reponseResult.ErrorMessage = ErrorMessage.UserNameOrPasswordInCorrect;
                return reponseResult;
            }
            string token = GenerateToken(user);
            reponseResult.SetSuccess(token);
            return reponseResult;

        }


        private string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Role , user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["tokenConfig:key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescript = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = cred ,
                Issuer = _config["tokenConfig:issuer"]
            };
            var tokenHanlder = new JwtSecurityTokenHandler();
            var token = tokenHanlder.CreateToken(tokenDescript);
            return tokenHanlder.WriteToken(token);
        }
    }
}
