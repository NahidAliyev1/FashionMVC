using FashionMVCProject.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FashionMVCProject.MVC.Contexts;

public class AppDbContext:DbContext
{
    public DbSet<FeaturedProducts> FeaturedProducts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=WINDOWS-AEJTJIB;Database=FeaturedProductsDb;Trusted_Connection=True;TrustServerCertificate=True");

        base.OnConfiguring(optionsBuilder);
    }

}
