    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Web.Infrastracture.Repository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll(string? includeProperty = null);
        public T Get(Expression<Func<T,bool>> filter, string? includeProperty = null);
        public void Create(T entity);
        public void Delete(T entity);
    }
}
