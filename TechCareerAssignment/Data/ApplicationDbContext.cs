﻿using Microsoft.EntityFrameworkCore;
using TechCareerAssignment.Models;

namespace TechCareerAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
