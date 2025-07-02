using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.UsuarioDtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int RolUsuarioId { get; set; }
        public string? RolUsuarioNombre { get; set; }  // Para exponer el nombre del rol
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Documento { get; set; }
        public string? Telefono { get; set; }
    }
}