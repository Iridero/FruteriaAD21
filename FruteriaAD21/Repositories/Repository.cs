using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruteriaAD21.Models;
using Microsoft.EntityFrameworkCore;

namespace FruteriaAD21.Repositories
{
    public abstract class Repository<T> where T : class
    {
        private fruteriashopContext _context = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this._context = new fruteriashopContext();
            table = _context.Set<T>();
        }
        public Repository(fruteriashopContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
