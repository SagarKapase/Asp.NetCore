using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Repository
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
        : base(options)
        {
        }

        public EFCoreDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable Logging
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //optionsBuilder.UseLazyLoadingProxies(); //enabeling the lazy loading proxies
            try
            {
                var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

                var configSection = configBuilder.GetSection("ConnectionStrings");
                var connectionString = configSection["connString"];

                optionsBuilder.UseSqlServer(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }

    }
}
