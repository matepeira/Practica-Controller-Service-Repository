using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Práctica_Controller_Service_Repository.Entities;
namespace Práctica_Controller_Service_Repository.Data;

public class PracticeContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public PracticeContext(DbContextOptions<PracticeContext> options) : base(options)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Product producto1 = new Product()
        {
            Id = 1,
            Name = "Auriculares in-ear",
            Price = 3000,
        };

        modelBuilder.Entity<Product>().HasData(
            producto1);

        base.OnModelCreating(modelBuilder);
    }
}
