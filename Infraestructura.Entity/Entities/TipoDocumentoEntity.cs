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
    [Table("tipodocumento", Schema = "dbo")]
    public class TipoDocumentoEntity
    {
        [Key]
        [Column("idtipodocumento", TypeName = "int")]
        public int IdTipoDocumento { get; set; }

        [Column("nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
    }
}
