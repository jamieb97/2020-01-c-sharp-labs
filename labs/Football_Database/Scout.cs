using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Football_Database
{
    class Scout
    {
        public int ScoutID { get; set; }
        [Required]
        public string ScoutName { get; set; }
        public int PlayerID { get; set; }
        public string CountryBased { get; set; }
        public int? StaffAmount { get; set; }
    }
}
