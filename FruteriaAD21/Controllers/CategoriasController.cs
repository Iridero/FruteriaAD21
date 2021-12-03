using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
using FruteriaAD21.Repositories;
namespace FruteriaAD21.Controllers
{
    public class CategoriasController : Controller
    {
        fruteriashopContext context;
        public CategoriasController(fruteriashopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            CategoriasRepository repo = new CategoriasRepository(context);
            var cats = repo.GetAll();
            return View(cats);
        }

        public IActionResult Eliminar(int id)
        {
            var repo = new CategoriasRepository(context);
            return View(repo.GetById(id));
        }
        [HttpPost]
        public IActionResult Eliminar(Categoria datos)
        {
            var repo = new CategoriasRepository(context);
            var cat = repo.GetById(datos.Id);
            if (cat==null)
            {

            }
            return View();
        }
    }
}
