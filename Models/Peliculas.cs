using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcedimientosAlmacenados.Models
{
    [Table("Peliculas")]
    public class Peliculas
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("IdPelicula")]
            public int IdPeliucula { get; set; }
    
            [Column("Titulo")]
            public String Titulo { get; set; }

            [Column("Argumento")]
            public String Argumento { get; set; }
    }
}
