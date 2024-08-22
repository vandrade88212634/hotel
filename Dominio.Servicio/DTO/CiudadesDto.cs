
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Dominio.Servicio.DTO
{
    [ExcludeFromCodeCoverage]

    public class CiudadesDto
    {
       
        public int IdCiudades { get; set; }

      
        public string CodigoDaneCiudad { get; set; }

        
        public string Estado { get; set; }

       
        public string Pais { get; set; }


        public string Nombre { get; set; }


        public bool? IsSuccess { get; set; }

  
        public string? Message { get; set; }
    }
}
