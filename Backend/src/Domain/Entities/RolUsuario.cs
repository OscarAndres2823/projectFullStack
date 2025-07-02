using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RolUsuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}