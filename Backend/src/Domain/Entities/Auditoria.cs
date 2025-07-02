using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }
        public string? Accion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } 
        public DateTime Fecha { get; set; }
    }
}