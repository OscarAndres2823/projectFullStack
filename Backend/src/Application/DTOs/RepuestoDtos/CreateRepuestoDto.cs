using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.RepuestoDtos
{
    public class CreateRepuestoDto
    {
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}