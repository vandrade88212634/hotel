using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.DTO
{
    public  class DetalleReservaDto
    {
       
        public int IdDetalleReserva { get; set; }

      
        public int IdReserva { get; set; }

       
        public string Nombres { get; set; }

       
        public string Apellidos { get; set; }

       
        public int IdTipoDocumento { get; set; }

        public string nombreTipo { get; set; }

      
        
        public string numerodocumento { get; set; }

       
        public int IdGenero { get; set; }

        public string NombreGenero { get; set; }



       
        public string Email { get; set; }

        
        public string Telefono { get; set; }

        
        public string NombreContacto { get; set; }

       
        public string TelefonoContacto { get; set; }



        public bool? IsSuccess { get; set; }


        public string? Message { get; set; }
    }
}
