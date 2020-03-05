using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_68_mvc_website_2.Models
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string DriverRole { get; set; }
        public string Name { get; set; }
        public int ContractLength { get; set; }
        public int? TeamID { get; set; }
        public virtual Team Team { get; set; }
        public int? CarID { get; set; }
        public virtual Car Car { get; set; }
    }
}
