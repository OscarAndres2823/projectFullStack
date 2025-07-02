using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int Year { get; set; }
        public string? Vin { get; set; }
        public double? Kilometraje { get; set; }
        public ICollection<OrdenServicio>? OrdenesServicios { get; set; }

    }
}