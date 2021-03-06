using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;

using Microsoft.EntityFrameworkCore;


namespace FruteriaAD21.Repositories
{
    public abstract class Repository<T> where T:class
    {
        public fruteriashopContext Context { get; private set; }
        public Repository(fruteriashopContext context)
        {
            Context = context;
        }
        public Repository()
        {
           Context = new fruteriashopContext();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(object id)
        {
            return Context.Find<T>(id);
        }

        public void Insert(T entidad)
        {
            Context.Add(entidad);
            Save();
        }

        public void Update(T entidad)
        {
            Context.Update(entidad);
            Save();
        }

        public void Delete(T entidad)
        {
            Context.Remove(entidad);
            Save();
        }

        public void Save()
        {
            Context.SaveChanges();

        }
    }
}
