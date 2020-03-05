using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab_68_mvc_website_2.Models
{
    public class F1TeamDbContext : DbContext
    {
        public F1TeamDbContext(DbContextOptions<F1TeamDbContext> options)
            : base(options) { }
        //dbset = sql table names 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Principle> Principles { get; set; }
        public DbSet<Technical> Technicals { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }


        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = F1TeamDatabase";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>().HasData(
                new Team { TeamID = 1, TeamName = "Scuderia Ferrari", TeamBudget = 250000000},
                new Team { TeamID = 2, TeamName = "Mercedes", TeamBudget = 200500000}
                );

            builder.Entity<Principle>().HasData(
                new Principle { PrincipleID = 1, PrincipleName = "Mattia Binotto", TeamID = 1, StrategyPlan = 1}
                );

            builder.Entity<Technical>().HasData(
                new Technical { TechnicalID = 1, TechnicalDirector = "James Allison", AeroRating = 8, EngineSupplier = "Ferrari", ChassisRating = 7}
                );

            builder.Entity<Driver>().HasData(
                new Driver { DriverID = 1, Name = "Sebastian Vettel",DriverRole = "First", ContractLength = 2, TeamID = 1}
                );

            builder.Entity<Car>().HasData(
                new Car { CarID = 1, CarName = "SF1000", TeamID = 1}
                );
        }
    }
}
