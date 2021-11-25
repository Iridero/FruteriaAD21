using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Repositories;
using FruteriaAD21.Models;
namespace FruteriaAD21.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("{id}")]
        public IActionResult Categoria(string id)
        {
            ViewBag.Categoria = id;
            var pr = new ProductosRepository();
            return View(pr.GetAll());
        }
    }
}
