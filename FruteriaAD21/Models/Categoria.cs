using System;
using System.Collections.Generic;

#nullable disable

namespace FruteriaAD21.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
