using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.VehiculoDtos
{
    public class UpdateVehiculoDto
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Year { get; set; }
        public string? Vin { get; set; }
        public double? Kilometraje { get; set; }
    }
}