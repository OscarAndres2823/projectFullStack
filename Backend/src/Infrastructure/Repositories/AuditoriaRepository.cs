using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AuditoriaRepository : GenericRepository<Auditoria>, IAuditoriaRepository
    {
        protected readonly SgtaDbContext _context;
        public AuditoriaRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}