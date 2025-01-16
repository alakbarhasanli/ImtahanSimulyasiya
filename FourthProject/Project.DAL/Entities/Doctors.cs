using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Doctors:AuditableEntitiy
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? DoctorPhoto { get; set; }
        public Department? department { get; set; }
        public int DepartmentId { get; set; }
    }
}
