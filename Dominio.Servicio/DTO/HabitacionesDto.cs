using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    [ExcludeFromCodeCoverage]
    public class HabitacionesDto
    {
       
        public int IdHabitaciones { get; set; }

       
        public string Numero { get; set; }


        
        public string Piso { get; set; }

      
       
        public decimal PrecioNoche { get; set; }

       
        public int IdTipo { get; set; }

        public string NombreTipo { get; set; }

        
        public string Ubicacion { get; set; }

       
        public int IdHotel { get; set; }

        public decimal ValorImpuestos { get; set; }

        public int Activo { get; set; }

        public bool? IsSuccess { get; set; }


        public string? Message { get; set; }
    }
}
