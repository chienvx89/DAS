using DAS.Infrastructure.Data.DAS.Models;
using DAS.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Infrastructure.Data.DAS.Context
{
    public class DASContext: DbContext
    {
        public DASContext(DbContextOptions<DASContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigUtils.GetConnectionString("DASContext"));
            //optionsBuilder.UseSqlServer("Server=ADMIN\\MSSQLSERVER2019;Database=QLCV01; User Id = sa;password=12345678;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            //builder.Entity<Job>().HasIndex(u => new { u.Name, u.ProjectId }).IsUnique();
            //builder.Entity<Project>().HasIndex(u => u.Name).IsUnique();
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<Project> Projects { get; set; }
    }
}
