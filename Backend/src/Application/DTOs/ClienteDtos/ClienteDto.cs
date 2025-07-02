using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.VehiculoDtos;

namespace Application.DTOs.ClienteDtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Documento { get; set; }
        public string? Correo { get; set; }
        public ICollection<VehiculoDto>? Vehiculos { get; set; } // Asumiendo que tienes un VehiculoDto
    }
}