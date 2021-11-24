using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
namespace FruteriaAD21.Repositories
{
    public class CategoriasRepository : Repository<Categoria>
    {
        public CategoriasRepository():base()
        {

        }
        public IEnumerable<string> GetNombresCategorias(){
            return GetAll().OrderBy(c => c.Nombre).Select(c => c.Nombre);    
        }
    }
}
