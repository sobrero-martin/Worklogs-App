using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs.DB.Data.Entities;

namespace Worklogs.DB.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet <Report> Reports { get; set; }
        public DbSet <Project> Projects { get; set; }
        public DbSet <MonthlyProjectHistory> MonthlyProjectHistories { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            // Example: modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
