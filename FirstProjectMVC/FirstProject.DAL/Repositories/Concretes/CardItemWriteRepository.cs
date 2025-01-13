using FirstProject.DAL.Contexts;
using FirstProject.DAL.Entitites;
using FirstProject.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Concretes
{
    public class CardItemWriteRepository : WriteRepository<CardItem>, ICardItemWriteRepository
    {
        private readonly FirstProjectDbContext _context;

        public CardItemWriteRepository(FirstProjectDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
