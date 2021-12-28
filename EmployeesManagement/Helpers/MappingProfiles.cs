using AutoMapper;
using Domain.CountryDto;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagement.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           

            //CreateMap<Address, AddressDto>().ReverseMap();
            //CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<CountryDto, Country>();
            CreateMap<Employee,  EmployeeSimpleDto>();
            CreateMap<EmployeeDetailsDto, Employee>().ReverseMap();


        }
    }
}
