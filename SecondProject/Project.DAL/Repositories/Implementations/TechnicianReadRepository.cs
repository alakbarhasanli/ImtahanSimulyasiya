using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class TechnicianReadRepository:ReadRepository<Technicians>,ITechnicianReadRepository
    {
        public TechnicianReadRepository(SecondProjectDbContext  context):base(context)
        {
            
        }
    }
}
