using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        protected readonly SgtaDbContext _context;
        public VehiculoRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}