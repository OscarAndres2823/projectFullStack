using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DetalleOrdenRepository : GenericRepository<DetalleOrden>, IDetalleOrdenRepository
    {
        protected readonly SgtaDbContext _context;
        public DetalleOrdenRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}