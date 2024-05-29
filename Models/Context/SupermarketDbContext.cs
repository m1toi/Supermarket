using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Supermarket.Models.Entities;
using Supermarket.Services;

namespace Supermarket.Models.Context
{
    public class SupermarketDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ReceiptProducts> ReceiptProducts { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=mitoi;Database=Supermarket;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
