using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
using Microsoft.EntityFrameworkCore;

namespace FruteriaAD21.Repositories
{
    public class ProductosRepository:Repository<Producto>
    {
        public Producto GetProductoByNombre(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            return Context.Productos
                .Include(x => x.IdCategoriaNavigation)
                .FirstOrDefault(p => p.Nombre.ToLower() == nombre);
        }
    }
}
