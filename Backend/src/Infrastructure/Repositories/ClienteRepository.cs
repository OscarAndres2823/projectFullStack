using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        protected readonly SgtaDbContext _context;
        public ClienteRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}