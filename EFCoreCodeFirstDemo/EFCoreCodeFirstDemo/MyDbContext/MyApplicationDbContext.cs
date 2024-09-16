using EFCoreCodeFirstDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstDemo.MyDbContext
{
    public class MyApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json") // Specify the configuration file to load.
                .Build(); // Build the configuration object, making it ready to retrieve values.
            
            var configSection = configBuilder.GetSection("ConnectionStrings");
            
            var connectionString = configSection["SQLServerConnection"] ?? null;
            
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
