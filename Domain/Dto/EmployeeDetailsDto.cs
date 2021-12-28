using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EmployeeDetailsDto
    {
        
        public int Id { get; set; }
        [Required]
        public string   FullName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string   PhoneNumber { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
