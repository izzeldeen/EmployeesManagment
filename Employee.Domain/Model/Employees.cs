using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Model
{
    public class Employees : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Salary { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
