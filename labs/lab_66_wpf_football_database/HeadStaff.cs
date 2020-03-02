using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_66_wpf_football_database
{
    public class HeadStaff
    {
        public int HeadStaffID { get; set; }
        public int? OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
        public string StaffName { get; set; }
        public string StaffRole { get; set; }
        public int? ScoutID { get; set; }
        public virtual Scout Scout { get; set; }
    }
}
