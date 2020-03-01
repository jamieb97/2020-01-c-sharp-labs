using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Football_Database
{
    class HeadStaff
    {
        public int ClubID { get; set; }
        public string StaffName { get; set; }
        public string StaffRole { get; set; }
        public int ScoutID { get; set; }
        public int RecruiterID { get; set; }
    }
}
