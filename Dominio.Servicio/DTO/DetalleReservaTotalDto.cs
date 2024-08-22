using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class DetalleReservaTotalDto
    {
        public List<DetalleReservaDto> detalleReservaDtos {  get; set; }    
        public List<HabitacionesReservaDto> habitacionesReserva {  get; set; }  
    }
}
