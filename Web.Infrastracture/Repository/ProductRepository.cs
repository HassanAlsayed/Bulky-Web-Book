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
    public class ProductRepository : Repository<Product>,IProductRepository 
    {
        private readonly BulkyDbContext _db;

        public ProductRepository(BulkyDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Product product)
        {
           var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.Price = product.Price;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price100 = product.Price100;
                objFromDb.Price50 = product.Price50;
                objFromDb.Author = product.Author;
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
              
            }
        }
    }
}
