using Assignment02.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment02.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                              .ToTable("Category")
                              .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Id)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500)
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                            .Property(p => p.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(100)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.Manufacture)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);
            modelBuilder.Entity<Product>()
                            .Property(p => p.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .HasData(new Category
                            {
                                Id = 1,
                                CategoryName = "Computer"
                            });
            modelBuilder.Entity<Product>()
                            .HasData(new Product
                            {
                                Id = 1,
                                ProductName = "Computer",
                                CategoryId = 1,
                                Manufacture = "Test"
                            });

        }

        public DbSet<Category> Categories { get; set; } = null!;
        
        public DbSet<Product> Products { get; set; } = null!;
    }
}