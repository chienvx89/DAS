using DAS.Domain.Models.DAS;
using DAS.Infrastructure;
using DAS.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAS.Infrastructure.Contexts
{
    public class DASContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder
                           .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                           .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
                           .AddConsole();
                }
        );

        public DASContext(DbContextOptions<DASContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer(ConfigUtils.GetConnectionString("DASContext"));
            //optionsBuilder.UseSqlServer(ConfigUtils.GetConnectionString("DASContext"));
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