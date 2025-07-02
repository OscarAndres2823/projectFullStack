using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RepuestoRepository : GenericRepository<Repuesto>, IRepuestoRepository
    {
        protected readonly SgtaDbContext _context;
        public RepuestoRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}