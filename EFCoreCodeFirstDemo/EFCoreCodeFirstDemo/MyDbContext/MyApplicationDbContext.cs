using EFCoreCodeFirstDemo.Entities;
using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Server=UTS-SAGARK;Database=EFCoreDb1;User Id=sa;Password=uts@123;TrustServerCertificate=True");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}
