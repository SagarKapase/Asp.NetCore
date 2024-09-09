using EFCoreDemoApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoApplication.DatabaseContext
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public string ConnectionString { get; }

        public BloggingContext()
        {
            ConnectionString = "Server = UTS-SAGARK; Initial Catalog=DotNetCoreFirstApplication; User Id =sa; Password=uts@123;TrustServerCertificate=True";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer(ConnectionString);

    }
}
