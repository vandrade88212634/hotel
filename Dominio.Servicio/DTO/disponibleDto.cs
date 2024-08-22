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
    public class disponibleDto
    {
       
      
        public DateTime Fecha { get; set; }

       
        public int IdHabitacion { get; set; }

        public string Numero { get; set; }



        public decimal PrecioNoche { get; set; }
    }
}
