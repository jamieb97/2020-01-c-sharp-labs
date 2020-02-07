using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace lab_51_entity_core_sql_sqlite
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Category> categories = new List<Category>();
        static void Main(string[] args)
        {
            using (var db = new UserDatabaseContext())
            {
                users = db.Users.ToList();
                categories = db.Categories.ToList();

                users.ForEach(i => Console.WriteLine(i.UserName));
                categories.ForEach(i => Console.WriteLine(i.CategoryName));
            }
        }
    }

    class UserDatabaseContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Users; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");


            //builder.UseSqlite(@"c:\");
        }
    }

    public class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public bool? isValid { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Users = new HashSet<User>();
        }

        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }


}
