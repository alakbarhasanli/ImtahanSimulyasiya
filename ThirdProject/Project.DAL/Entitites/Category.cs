using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entitites
{
    public class Category:AuditableEntity
    {
        public string Title { get; set; }
        public ICollection<News> news { get; set; }
    }
}
