using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Infraestructura.Entity.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("ciudades", Schema = "dbo")]
    public class CiudadesEntity
    {
        [Key]
        [Column("idciudades", TypeName = "int")]
        public int IdCiudades{ get; set; }

        [Required]
        [Column("codigodane", TypeName = "Varchar(10)")]
        public string CodigoDaneCiudad { get; set; }

        [Required]
        [Column("estado", TypeName = "varchar(50)")]
        public string Estado { get; set; }

        [Required]
        [Column("pais", TypeName = "Varchar(50)")]
        public string Pais { get; set; }


        [Required]
        [Column("nombre", TypeName = "Varchar(50)")]
        public string Nombre { get; set; }

       
    }
}
