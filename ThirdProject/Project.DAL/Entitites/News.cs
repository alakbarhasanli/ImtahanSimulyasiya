using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entitites
{
    public class News :AuditableEntity
    {
       
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? NewsPhoto { get; set; }
        
        public Category? category { get; set; }
        public int CategoryId { get; set; }

    }
}
