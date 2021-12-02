using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
using FruteriaAD21.Repositories;

namespace FruteriaAD21.Services
{
    public interface ICategoriasService
    {
        IEnumerable<Categoria> GetCategorias();
        IEnumerable<String> GetNombresCategorias();
    }
    public class CategoriasService : ICategoriasService
    {
        public IEnumerable<Categoria> GetCategorias()
        {
            var repo = new CategoriasRepository();
            return repo.GetAll();
        }

        public IEnumerable<string> GetNombresCategorias()
        {
            var repo = new CategoriasRepository();
            return repo.GetNombresCategorias();
        }
    }
}
