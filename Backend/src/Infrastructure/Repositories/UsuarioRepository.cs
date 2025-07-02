using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        protected readonly SgtaDbContext _context;
        public UsuarioRepository(SgtaDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Usuario> GetByCorreoAsync(string correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }
    }
}