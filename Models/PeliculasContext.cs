using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProcedimientosAlmacenados.Models
{
    #region procedimientos
    //CREATE PROCEDURE MOSTRARPELICULAS
    //AS
    //SELECT* FROM Peliculas
    //GO
    //CREATE PROCEDURE MOSTRARPELICULA(@ID INT)
    //AS
    //SELECT* FROM Peliculas WHERE IdPelicula = @ID
    //GO
    //CREATE PROCEDURE CAMBIARTITULO(@ID INT, @TITULO NVARCHAR(50))
    //AS
    //UPDATE PELICULAS SET TITULO = @TITULO WHERE IdPelicula = @ID
    //GO
    #endregion
    public class PeliculasContext : DbContext
    {
        public PeliculasContext(DbContextOptions options) : base(options) { }
        public DbSet<Peliculas> Peliculas { get; set; }

        public List<Peliculas> MostrarPeliculas()
        {
            String sql = "MOSTRARPELICULAS";
            return this.Peliculas.FromSql(sql).ToList();
        }
        public Peliculas MostrarPelicula(int id)
        {
            String sql = "MOSTRARPELICULA @ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            return this.Peliculas.FromSql(sql,pamid).SingleOrDefault();
        }

        public int CambiarTitulo(int id, string titulo)
        {
            String sql = "CAMBIARTITULO @ID,  @TITULO";
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamtit = new SqlParameter("@TITULO", titulo);
            return this.Database.ExecuteSqlCommand(sql, pamid,pamtit);

        }
    }
}
