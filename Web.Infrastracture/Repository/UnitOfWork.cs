
using Web.Infrastracture.Data;


namespace Web.Infrastracture.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BulkyDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }
      
        public UnitOfWork(BulkyDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
         
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
