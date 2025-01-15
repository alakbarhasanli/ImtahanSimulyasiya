using Project.DAL.Contexts;
using Project.DAL.Entitites;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class NewsRepository: GenericRepository<News>, INewsRepository
    {
        public NewsRepository(ThirdProjectDbContext context) : base(context)
        {

        }
    }
}
