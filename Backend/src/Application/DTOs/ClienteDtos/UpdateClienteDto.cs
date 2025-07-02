using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.ClienteDtos
{
    public class UpdateClienteDto
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Documento { get; set; }
        public string? Correo { get; set; }
    }
}