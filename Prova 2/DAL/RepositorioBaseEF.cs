using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Produtos
{
     public class RepositorioBaseEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public RepositorioBaseEF(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Incluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }

        public void Alterar(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Excluir(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }
    }
}
