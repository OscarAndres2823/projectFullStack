using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.RolUsuarioDto
{
    public class RolUsuarioDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<string>? UsuariosNombres { get; set; }
    }
}