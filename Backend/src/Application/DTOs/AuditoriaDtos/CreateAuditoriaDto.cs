using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.AuditoriaDtos
{
    public class CreateAuditoriaDto
    {
        public string? Entidad { get; set; }
        public string? Accion { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
    }
}