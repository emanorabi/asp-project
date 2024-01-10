using app2api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace app2api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
