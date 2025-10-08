using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FIRATALCIN\\NOVALSN;initial catalog=ApiDemoDb;integrated security=true;trustservercertificate=true");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
