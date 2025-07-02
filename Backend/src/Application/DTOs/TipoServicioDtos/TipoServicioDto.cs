using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.TipoServicioDtos
{
    public class TipoServicioDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<int>? OrdenServiciosIds { get; set; }
    }
}