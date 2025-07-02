using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.DetalleDtos
{
    public class UpdateDetalleOrdenDto
    {
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
    }
}