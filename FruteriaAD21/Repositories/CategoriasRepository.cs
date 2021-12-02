using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;


namespace FruteriaAD21.Repositories
{
    public class CategoriasRepository:Repository<Categoria>
    {
        public CategoriasRepository(fruteriashopContext context):base(context)
        {

        }
        public override IEnumerable<Categoria> GetAll()
        {
            return base.GetAll().Where(c=>!c.Eliminado);
}

        public CategoriasRepository():base()
        {

        }
        public IEnumerable<string> GetNombresCategorias(){
            return GetAll().OrderBy(c => c.Nombre).Select(c => c.Nombre);    

        }
    }
}
