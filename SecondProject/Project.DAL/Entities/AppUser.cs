using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class AppUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }
}
