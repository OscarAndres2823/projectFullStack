using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Documento { get; set; }
        public string? Correo { get; set; }
        public ICollection<Vehiculo>? Vehiculos { get; set; }
    }
}