using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Employee : EntityBase
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
