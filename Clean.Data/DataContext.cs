
using Clean.Core.Entities;
using Clean.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
       : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Vacations> Vacations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<WorkingHours>()
        //        .HasOne(e => e.User)
        //        .WithMany(e => e.WorkingHours)
        //        .HasForeignKey(e => e.UserId)
        //        .IsRequired();

        //    modelBuilder.Entity<Vacations>()
        //     .HasOne(e => e.User)
        //     .WithMany(e => e.Vacations)
        //     .HasForeignKey(e => e.UserId)
        //     .IsRequired();
        //}
    }
}


