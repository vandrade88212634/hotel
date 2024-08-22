using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("hotel", Schema = "dbo")]
    public class HotelEntity
    {
        [Key]
        [Column("idhotel", TypeName = "int")]
        public int IdHotel { get; set; }

        [Column("razonsocial", TypeName = "varchar(45)")]
        public string RazonSocial { get; set; }

        [Column("direccion", TypeName = "varchar(45)")]
        public string Direccion { get; set; }


        [Column("telreservas", TypeName = "varchar(45)")]
        public string TelReservas { get; set; }

        [Column("idciudades", TypeName = "int")]
        public int IdCiudades { get; set; }

        [Column("activo", TypeName = "int")]
        public int Activo { get; set; }



    }
}
