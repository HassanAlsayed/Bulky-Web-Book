using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Model;
using Web.Infrastracture.Data;

namespace Web.Infrastracture.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository 
    {
        private readonly BulkyDbContext _db;

        public CategoryRepository(BulkyDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Category category)
        {
           _db.Categories.Update(category);
        }
    }
}
