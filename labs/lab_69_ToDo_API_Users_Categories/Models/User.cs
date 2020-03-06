using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_69_ToDo_API_Users_Categories.Models
{
    public class User
    {
        public User()
        {
            ToDos = new HashSet<ToDo>();
        }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public ICollection<ToDo> ToDos { get; set; }

    }
}
