using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int RolUsuarioId { get; set; }
        public RolUsuario? RolUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
        public string? Documento { get; set; }
        public string? Telefono { get; set; }
        public ICollection<Auditoria>? Auditorias { get; set; }
        public ICollection<OrdenServicio>? OrdenServicios { get; set; }
    }
}