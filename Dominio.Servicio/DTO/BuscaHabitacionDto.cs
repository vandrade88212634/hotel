using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class BuscaHabitacionDto
    {
        public int? IdCiudades { get; set; }
        public int? IdTipo { get; set; }
        public int? IdHotel { get; set; }

        public DateTime? FecEntrada { get; set; } 
        public DateTime? FecSalida { get; set; }
    }
}
