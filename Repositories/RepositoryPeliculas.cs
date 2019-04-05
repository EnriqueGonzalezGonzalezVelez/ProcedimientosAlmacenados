using ProcedimientosAlmacenados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcedimientosAlmacenados.Repositories
{
    public class RepositoryPeliculas
    {
        PeliculasContext context;
        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }
        public Peliculas MostrarPelicula(int id)
        {
            return this.context.MostrarPelicula(id);
        }
        public List<Peliculas> MostrarPeliculas()
        {
            return this.context.MostrarPeliculas();
        }

        public int CambiarTitulo(int id, string titulo)
        {
            return this.context.CambiarTitulo(id, titulo);
        }
    }
}
