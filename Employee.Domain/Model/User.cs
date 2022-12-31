using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Model
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
      //  public Employees Employee { get; set; }
    }
}
