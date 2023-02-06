using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
    }
}
