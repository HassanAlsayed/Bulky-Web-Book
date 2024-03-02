using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastracture.Data;


namespace Web.Infrastracture.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BulkyDbContext _db;
        private readonly DbSet<T> dbSet;

      
        public Repository(BulkyDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

        public IEnumerable<T> GetAll(string? includeProperty = null) {

            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var includeProp in includeProperty
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Create(T entity)
        {
          dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperty = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var includeProp in includeProperty
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
