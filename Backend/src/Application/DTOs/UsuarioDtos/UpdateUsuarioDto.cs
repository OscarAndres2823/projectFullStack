using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.UsuarioDtos
{
    public class UpdateUsuarioDto
    {
        public int RolUsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; } // Opcional: permite cambiar la clave
        public string? Documento { get; set; }
        public string? Telefono { get; set; }
    }
}