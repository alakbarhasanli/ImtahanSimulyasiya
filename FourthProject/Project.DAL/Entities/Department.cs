using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Department:AuditableEntitiy
    {
        public string Name { get; set; }
        public ICollection<Doctors> doctors { get; set; }
    }
}
