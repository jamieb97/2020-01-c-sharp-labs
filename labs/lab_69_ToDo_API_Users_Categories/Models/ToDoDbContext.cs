using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab_69_ToDo_API_Users_Categories.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }

        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ToDoDatabase";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany(u => u.ToDos).WithOne(u => u.User);

            builder.Entity<User>().Property(u => u.UserName).IsRequired();

            builder.Entity<User>().HasData(
                new User { UserID = 1, UserName= "Jamie"},
                new User { UserID = 2, UserName= "Karim"},
                new User { UserID = 3, UserName= "Tim"}
                );

            builder.Entity<ToDo>().HasData(
                new ToDo { ToDoID = 1, ToDoName = "Do This"},
                new ToDo { ToDoID = 2, ToDoName = "And do this"},
                new ToDo { ToDoID = 3, ToDoName = "Also do this"}
                );
        }
    }
}
