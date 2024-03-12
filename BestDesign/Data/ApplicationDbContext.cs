using BestDesign.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestDesign.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

 
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> fAQs { get; set; }
        public DbSet<Order> Orders { get; set; }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }

    }
}