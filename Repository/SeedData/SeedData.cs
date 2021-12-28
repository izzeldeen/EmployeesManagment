using Domain.Entities;
using Domain.IRepository;
using Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enum.Enum;

namespace Service.SeedData
{
    public  class SeedData
    {
        public static async Task SeedAsync(StoreContext context)
        {
            
            if (!context.Countries.Any() && !context.Departments.Any() && !context.Employees.Any())
            {
                Country country = new Country()
                {
                    Id = 0,
                    Name = "Jordan",
                    CreateDate = DateTime.Now,
                    IsActive = (byte)Status.Active
                };
              

                Department department = new Department()
                {
                    Id = 0,
                    Name = "HR",
                    CreateDate = DateTime.Now,
                    IsActive = (byte)Status.Active
                };
              
                Employee employee = new Employee()
                {
                    Id = 0,
                    FullName = "Izzeldeen Kalbouneh",
                    CreateDate = DateTime.Now,
                    IsActive = (byte)Status.Active,
                    Department = department,
                    Salary = 500,
                    Country = country
                };
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }

            
        }
    }
}
