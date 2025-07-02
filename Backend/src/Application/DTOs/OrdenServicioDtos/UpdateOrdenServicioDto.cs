using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.OrdenServicioDtos
{
    public class UpdateOrdenServicioDto
    {
        public int TipoServicioId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEstimada { get; set; }
    }
}