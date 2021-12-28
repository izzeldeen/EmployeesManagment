using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public byte IsActive { get; set; }
    }
}
