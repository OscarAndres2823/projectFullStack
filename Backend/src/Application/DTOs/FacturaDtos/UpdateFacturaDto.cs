using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.FacturaDtos
{
    public class UpdateFacturaDto
    {
        public decimal MontoTotal { get; set; }
        public decimal ManoObra { get; set; }
        public decimal ValorTotal { get; set; }
    }
}