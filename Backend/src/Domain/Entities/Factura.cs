using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public int OrdenServicioId { get; set; }
        public OrdenServicio? OrdenServicio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal ManoObra { get; set; }
        public decimal ValorTotal { get; set; }
    }
}