using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_66_wpf_football_database
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public int? HeadStaffID { get; set; }
        public virtual HeadStaff HeadStaff { get; set; }
        public int? AgentFee { get; set; }
        public int? PercentOwned { get; set; }
    }
}
