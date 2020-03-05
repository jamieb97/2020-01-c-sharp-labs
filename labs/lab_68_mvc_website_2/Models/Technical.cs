using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_68_mvc_website_2.Models
{
    public class Technical
    {
        public int TechnicalID { get; set; }
        public string TechnicalDirector { get; set; }
        public int AeroRating { get; set; }
        public string EngineSupplier { get; set; }
        public int ChassisRating { get; set; }
        public int? TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}
