using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public bool Habilited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
