using FirstWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.DataDbContext
{
    public class ApplicationDbContext : DbContext //Represent the database connection
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; } //represent the table in the database
    }
}
