using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.DetalleDtos
{
    public class DetalleOrdenDto
    {
        public int Id { get; set; }
        public int OrdenServicioId { get; set; }
        public int RepuestoId { get; set; }
        public string? RepuestoNombre { get; set; }  // Si quieres exponer el nombre del repuesto
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
    }
}