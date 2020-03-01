using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Football_Database
{
    class Agent
    {
        public int AgentID { get; set; }
        [Required]
        public string AgentName { get; set; }
        public int RecruiterID { get; set; }
        public uint? AgentFee { get; set; }
        public int? PercentOwned { get; set; }
    }
}
