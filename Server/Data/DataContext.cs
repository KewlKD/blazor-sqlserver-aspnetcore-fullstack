using System.Collections.Generic;
using System.Reflection.Emit;
using BlazorSQLServerAspNetCoreFullStack.Shared;
using Microsoft.EntityFrameworkCore;


namespace BlazorSQLServerAspNetCoreFullStack.Server.Data
{
   
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Lex",
                        LastName = "Micheals",
                        Email = "lm@me.com"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Mike",
                        LastName = "Hampton",
                        Email = "mh@me.com"
                    },
                   
                    new User
                    {
                        Id = 4,
                        FirstName = "Kay",
                        LastName = "Bills",
                        Email = "kb@me.com"
                    });

        }

        public DbSet<User> Users => Set<User>();
    }
}
