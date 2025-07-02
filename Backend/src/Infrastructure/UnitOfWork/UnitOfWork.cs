using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SgtaDbContext _context;
        private IAuditoriaRepository? _auditoria;
        private IClienteRepository? _cliente;
        private IDetalleOrdenRepository? _detalleOrden;
        private IFacturaRepository? _factura;
        private IOrdenServicioRepository? _ordenServicio;
        private IRepuestoRepository? _repuesto;
        private IRolUsuarioRepository? _rolUsuario;
        private ITipoServicioRepository? _tipoServicio;
        private IUsuarioRepository? _usuario;
        private IVehiculoRepository? _vehiculo;
        public UnitOfWork(SgtaDbContext context)
        {
            _context = context;
        }

        public IAuditoriaRepository Auditorias => _auditoria ??= new AuditoriaRepository(_context!);
        public IClienteRepository Clientes => _cliente ??= new ClienteRepository(_context!);
        public IDetalleOrdenRepository DetalleOrdenes => _detalleOrden ??= new DetalleOrdenRepository(_context!);
        public IFacturaRepository Facturas => _factura ??= new FacturaRepository(_context!);
        public IOrdenServicioRepository OrdenesServicio => _ordenServicio ??= new OrdenServicioRepository(_context!);
        public IRepuestoRepository Repuestos => _repuesto ??= new RepuestoRepository(_context!);
        public IRolUsuarioRepository RolUsuarios => _rolUsuario ??= new RolUsuarioRepository(_context!);
        public ITipoServicioRepository TipoServicios => _tipoServicio ??= new TipoServicioRepository(_context!);
        public IUsuarioRepository Usuarios => _usuario ??= new UsuarioRepository(_context!);
        public IVehiculoRepository Vehiculos => _vehiculo ??= new VehiculoRepository(_context!);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}