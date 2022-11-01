using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MG0GJ9S\\SQLEXPRESS;database=ProductDb; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<BaseUser>().HasKey(x => x.Id);
            modelBuilder.Entity<BaseUser>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<BaseUser>().Property(x => x.NameSurname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<BaseUser>().Property(x => x.UserName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<BaseUser>().Property(x => x.Password).IsRequired().HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }
       
   
        
    }
}
