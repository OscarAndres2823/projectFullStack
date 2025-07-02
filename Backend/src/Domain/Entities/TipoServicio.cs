using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoServicio
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<OrdenServicio>? OrdenServicios { get; set; }
    }
}