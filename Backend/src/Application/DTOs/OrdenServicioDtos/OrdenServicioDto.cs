using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.DetalleDtos;
using Application.DTOs.FacturaDtos;

namespace Application.DTOs.OrdenServicioDtos
{
    public class OrdenServicioDto
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public string? VehiculoDescripcion { get; set; } // opcional: puedes mapear placa o modelo
        public int TipoServicioId { get; set; }
        public string? TipoServicioNombre { get; set; } // opcional: nombre del tipo de servicio
        public int? UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; } // opcional: nombre del usuario
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public ICollection<DetalleOrdenDto>? DetalleOrdenes { get; set; }
        public ICollection<FacturaDto>? Facturas { get; set; }
    }
}