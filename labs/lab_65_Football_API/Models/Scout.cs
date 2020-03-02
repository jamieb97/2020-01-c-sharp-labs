using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_65_Football_API.Models
{
    public class Scout
    {
        public int ScoutID { get; set; }
        public string ScoutName { get; set; }
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public string CountryBased { get; set; }
        public int? StaffAmount { get; set; }
    }
}
