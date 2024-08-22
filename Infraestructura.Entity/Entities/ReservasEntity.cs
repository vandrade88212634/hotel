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
    [Table("reservas", Schema = "dbo")]
    public class ReservasEntity
    {
        [Key]
        [Column("idreservas", TypeName = "int")]
        public int IdReservas { get; set; }

        [Column("idhotel", TypeName = "int")]
        public int IdHotel { get; set; }

        [Column("fecentrada", TypeName = "datetime2")]
        public DateTime FecEntrada { get; set; }

        [Column("fecsalida", TypeName = "datetime2")]
        public DateTime FecSalida { get; set; }

        [Column("idciudad", TypeName = "int")]
        public int IdCiudad { get; set; }

        [Column("cantidadhusespedes", TypeName = "int")]
        public int CantidadHuespedes { get; set; }


    }
}
