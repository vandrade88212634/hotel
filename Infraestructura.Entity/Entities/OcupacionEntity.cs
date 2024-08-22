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
    [Table("ocupacion", Schema = "dbo")]
    public class OcupacionEntity
    {
        [Key]
        [Column("idocupacion", TypeName = "int")]
        public int IdOcupacion { get; set; }

        [Column("fecha", TypeName = "datetime2")]
        public DateTime  Fecha { get; set; }

        [Column("idhabitacion", TypeName = "int")]
        public int IdHabitacion { get; set; }

        [Column("idreserva", TypeName = "int")]
        public int IdReserva { get; set; }





    }
}
