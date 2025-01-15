using Microsoft.AspNetCore.Http;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
    }
}
