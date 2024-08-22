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
    public class HotelDto
    {
       
        public int IdHotel { get; set; }

       
        public string RazonSocial { get; set; }

       
        public string Direccion { get; set; }


      
        public string TelReservas { get; set; }

        public int IdCiudades { get; set; }

        public string NombreCiudades { get; set; }
        public int Activo { get; set; }


        public bool? IsSuccess { get; set; }


        public string? Message { get; set; }

    }
}
