using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.AuditoriaDtos
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }
        public string? Accion { get; set; }
        public int UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}