using Microsoft.EntityFrameworkCore;
using Web.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Web.Infrastracture.Data
{
    public class BulkyDbContext : IdentityDbContext<IdentityUser>
    {
        public BulkyDbContext(DbContextOptions<BulkyDbContext> options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(

                new Category() { Id = Guid.Parse("1A191997-FEAA-4837-8B62-359349000F91"), Name = "Action", DisplayOrder = 1 },
                new Category() { Id = Guid.Parse("FF718B93-F78C-477C-ABD6-56D7D5A2A8D7"), Name = "SciFi", DisplayOrder = 2 },
                new Category() { Id = Guid.Parse("2D6F9B00-6E59-461B-99BE-C92701FBB6C8"), Name = "History", DisplayOrder = 3 }

            );
            modelBuilder.Entity<Product>().HasData(
       new Product
       {
           Id = Guid.NewGuid(),
           Title = "Fortune of Time",
           Author = "Billy Spark",
           Description = "des",
           ISBN = "SWD9999001",
           ListPrice = 99,
           Price = 90,
           Price50 = 85,
           Price100 = 80,
           CategoryId = Guid.Parse("1A191997-FEAA-4837-8B62-359349000F91"),
           ImageUrl = ""
          
           
       },
       new Product
       {
           Id = Guid.NewGuid(),
           Title = "Rock in the Ocean",
           Author = "Ron Parker",
           Description = "des",
           ISBN = "SOTJ1111111101",
           ListPrice = 30,
           Price = 27,
           Price50 = 25,
           Price100 = 20,
           CategoryId = Guid.Parse("FF718B93-F78C-477C-ABD6-56D7D5A2A8D7"),
           ImageUrl = ""

       },
       new Product
       {
           Id = Guid.NewGuid(),
           Title = "Cotton Candy",
           Author = "Abby Mucles",
           Description = "des",
           ISBN = "WS3333333301",
           ListPrice = 70,
           Price = 65,
           Price50 = 60,
           Price100 = 55,
           CategoryId = Guid.Parse("2D6F9B00-6E59-461B-99BE-C92701FBB6C8"),
           ImageUrl = ""

       }
   );


        }
    }
}
