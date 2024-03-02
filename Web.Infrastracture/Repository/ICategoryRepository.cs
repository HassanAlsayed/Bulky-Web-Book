using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Model;

namespace Web.Infrastracture.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public void Update(Category category);

     
       
    }
}
