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
    [Table("generos", Schema = "dbo")]
    public class GenerosEntity
    {
        [Key]
        [Column("idgeneros", TypeName = "int")]
        public int IdGeneros { get; set; }

        [Column("nombre", TypeName = "varchar(20)")]
        public string Nombre { get; set; }


    }
}
