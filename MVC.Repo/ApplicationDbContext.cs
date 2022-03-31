using Microsoft.EntityFrameworkCore;
using MVC.Data;
using System;

namespace MVC.Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CategoryMap(modelBuilder.Entity<Category>());

        }
    }
}
