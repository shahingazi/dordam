using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Models;

namespace PriceComparisonWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<SuperCategory> SuperCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SuperCategoryMappingCategory> SuperCategoryMappingCategories { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SuperCategoryMappingCategory>()
                .HasKey(bc => new { bc.SuperCategoryId, bc.CategoryId });
            modelBuilder.Entity<SuperCategoryMappingCategory>()
                .HasOne(bc => bc.SuperCategory)
                .WithMany(b => b.SuperCategoryMappingCategories)
                .HasForeignKey(bc => bc.SuperCategoryId);
            modelBuilder.Entity<SuperCategoryMappingCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.SuperCategoryMappingCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
