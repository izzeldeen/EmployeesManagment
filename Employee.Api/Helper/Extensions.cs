using Employee.DAL.Repository;
using Employee.Domain.IRepository;
using Employee.Domain.IService;
using Employee.Service.Services;

namespace Employee.Api.Helper
{
    public static class Extensions
    {
        public static IServiceCollection RegisterService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return builder.Services;
        }

    }
}
