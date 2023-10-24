using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace RazorEF
{
    public class MyWebContext : DbContext
    {
        public MyWebContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            // ...
        }

        public DbSet<Article> articles { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}