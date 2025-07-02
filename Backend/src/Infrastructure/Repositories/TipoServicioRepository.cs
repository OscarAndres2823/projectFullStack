using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoServicioRepository : GenericRepository<TipoServicio>, ITipoServicioRepository
    {
        protected readonly SgtaDbContext _context;
        public TipoServicioRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}