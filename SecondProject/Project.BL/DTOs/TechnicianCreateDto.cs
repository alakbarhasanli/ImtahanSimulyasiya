using Microsoft.AspNetCore.Http;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public class TechnicianCreateDto
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        [NotMapped]
        public IFormFile? TechniciansPhoto { get; set; }
        public int ServiceId { get; set; }
       
    }
}
