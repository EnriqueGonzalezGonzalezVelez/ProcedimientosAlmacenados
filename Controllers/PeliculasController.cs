using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcedimientosAlmacenados.Repositories;

namespace ProcedimientosAlmacenados.Controllers
{
    public class PeliculasController : Controller
    {

        RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            
            return View(this.repo.MostrarPeliculas());
        }
        public IActionResult Edit(int id)
        {

            return View(this.repo.MostrarPelicula(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, String titulo)
        {
            this.repo.CambiarTitulo(id, titulo);
            return RedirectToAction("Index");
        }
    }
}