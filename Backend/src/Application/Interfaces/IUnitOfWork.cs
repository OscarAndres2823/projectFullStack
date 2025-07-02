using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        IDetalleOrdenRepository DetalleOrdenes { get; }
        IAuditoriaRepository Auditorias { get; }
        IFacturaRepository Facturas { get; }
        IOrdenServicioRepository OrdenesServicio { get; }
        IRepuestoRepository Repuestos { get; }
        IRolUsuarioRepository RolUsuarios { get; }
        ITipoServicioRepository TipoServicios { get; }
        IUsuarioRepository Usuarios { get; }
        IVehiculoRepository Vehiculos { get; }
        Task<int> SaveAsync();
    }
}