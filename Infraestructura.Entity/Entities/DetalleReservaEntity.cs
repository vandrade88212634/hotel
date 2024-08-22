using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("detallereserva", Schema = "dbo")]
    public class DetalleReservaEntity
    {
        [Key]
        [Column("iddetallereserva", TypeName = "int")]
        public int IdDetalleReserva { get; set; }

        [Column("idreserva", TypeName = "int")]
        public int IdReserva { get; set; }

        [Column("nombres", TypeName = "varchar(50)")]
        public string  Nombres { get; set; }

        [Column("apellidos", TypeName = "varchar(50)")]
        public string Apellidos { get; set; }

        [Column("idtipodocumento", TypeName = "int")]
        public int IdTipoDocumento { get; set; }

        [Column("numerodocumento", TypeName = "varchar(50)")]
        public string numerodocumento { get; set; }

        [Column("idgenero", TypeName = "int")]
        public int IdGenero { get; set; }

        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column("telefono", TypeName = "varchar(50)")]
        public string Telefono { get; set; }

        [Column("nombrecontacto", TypeName = "varchar(100)")]
        public string NombreContacto { get; set; }

        [Column("telefonocontacto", TypeName = "varchar(50)")]
        public string TelefonoContacto { get; set; }



    }
}
