using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Technicians:AuditableEntity
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? TechniciansPhoto  { get; set; }
        public int ServiceId { get; set; }
        public Service? service { get; set; }

    }
}
