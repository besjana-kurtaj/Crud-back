using Crud_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Data
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>();
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
