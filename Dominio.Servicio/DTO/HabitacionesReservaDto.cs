using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class HabitacionesReservaDto
    {
        public int IdReserva { get; set; }
        public int IdHabitacion { get; set; }
        public string Piso {  get; set; }   
        public string Ubicacion { get; set; }
        public string Numero { get; set; }
        public DateTime fecha { get; set; }
    }
}
