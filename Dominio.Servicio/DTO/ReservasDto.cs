using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public class ReservasDto
    {
       
        public int IdReservas { get; set; }

      
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        
        public DateTime FecEntrada { get; set; }

        [Column("fecsalida", TypeName = "datetime2")]
        public DateTime FecSalida { get; set; }

       
        public int IdCiudad { get; set; }
        public string NombreCiudad { get; set; }

       
        public int CantidadHuespedes { get; set; }

        public List<DetalleReservaDto>? detalleReserva {  get; set; }
        public List<HabitacionesReservaDto>? habitacionesReserva { get; set; }

        public bool? IsSuccess { get; set; }


        public string? Message { get; set; }

    }
}
