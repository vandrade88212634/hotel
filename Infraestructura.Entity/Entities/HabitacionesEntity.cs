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
    [Table("habitaciones", Schema = "dbo")]
    public class HabitacionesEntity
    {
        [Key]
        [Column("idhabitaciones", TypeName = "int")]
        public int IdHabitaciones { get; set; }

        [Column("numero", TypeName = "varchar(10)")]
        public string Numero { get; set; }


        [Column("piso", TypeName = "varchar(10)")]
        public string Piso { get; set; }



        [Column("precionoche", TypeName = "decimal(18,2)")]
        public decimal PrecioNoche { get; set; }

        [Column("idtipo", TypeName = "int")]
        public int IdTipo { get; set; }

        [Column("ubicacion", TypeName = "varchar(100)")]
        public string Ubicacion { get; set; }

        [Column("idhotel", TypeName = "int")]
        public int IdHotel { get; set; }

        [Column("valorimpuestos", TypeName = "decimal(18,2)")]
        public decimal ValorImpuestos { get; set; }

        [Column("activo", TypeName = "int")]
        public int Activo { get; set; }


    }
}
