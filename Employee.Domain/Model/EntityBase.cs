using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Model
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
