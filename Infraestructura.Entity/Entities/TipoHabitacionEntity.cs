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
    [Table("tipohabitacion", Schema = "dbo")]
    public class TipoHabitacionEntity
    {
        [Key]
        [Column("idtipohabitacion", TypeName = "int")]
        public int IdTipoHabitacion { get; set; }

        [Column("idhotel", TypeName = "int")]
        public int IdHotel { get; set; }

        [Column("nombre", TypeName = "varchar(45)")]
        public string Nombre { get; set; }




    }
}
