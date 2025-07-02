using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrdenServicio
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }
        public int TipoServicioId { get; set; }
        public TipoServicio? TipoServicio { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public ICollection<DetalleOrden>? DetalleOrdenes { get; set; }
        public ICollection<Factura>? Facturas { get; set; }
    }
}