using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public int OrdenServicioId { get; set; }
        public OrdenServicio? OrdenServicio { get; set; }
        public int RepuestoId { get; set; }
        public Repuesto? Repuesto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
    }
}