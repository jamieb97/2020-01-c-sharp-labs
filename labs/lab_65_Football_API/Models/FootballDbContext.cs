using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_65_Football_API.Models
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options) { }
        //dbset = sql table names 
        public DbSet<Player> Players { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Scout> Scouts { get; set; }
        public DbSet<HeadStaff> HeadStaffs { get; set; }


        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FootballDatabase";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Agent>().HasData(
                new Agent { AgentID = 1, AgentName = "Mino Railo", AgentFee = 30, PercentOwned = 5 },
                new Agent { AgentID = 2, AgentName = "Mendes", AgentFee = 25, PercentOwned = 10 }
                );

            builder.Entity<Player>().HasData(
                new Player { PlayerID = 1, PlayerName = "Neymar", AgentID = 2, Age = 25, ContractLength = 5, Salary = 450000},
                new Player { PlayerID = 2, PlayerName = "Pogba", AgentID = 1, Age = 26, ContractLength = 3, Salary = 300000}
                );

            builder.Entity<Agent>().Property(a => a.AgentName).IsRequired().HasMaxLength(25);
        }
    }

}
