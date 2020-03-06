using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_69_ToDo_API_Users_Categories.Models
{
    public class ToDo
    {
        public int ToDoID { get; set; }
        public string ToDoName { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
    }
}
