using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_68_mvc_website_2.Models
{
    public class Principle
    {
        public int PrincipleID { get; set; }
        public string PrincipleName { get; set; }
        public int? TeamID { get; set; }
        public virtual Team Team { get; set; }
        public int StrategyPlan { get; set; }
        public int? TechnicalID { get; set; }
        public virtual Technical Technical { get; set; }
    }
}
