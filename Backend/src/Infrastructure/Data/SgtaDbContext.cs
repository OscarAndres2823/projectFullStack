using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class SgtaDbContext : DbContext
    {
        public SgtaDbContext(DbContextOptions<SgtaDbContext> options) : base(options) { }

        public DbSet<Auditoria> Auditorias { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<RolUsuario> RolesUsuarios { get; set; }
        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<OrdenServicio> OrdenesServicios { get; set; }
        public DbSet<Repuesto> Repuestos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoServicio> TiposServicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}