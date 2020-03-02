using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab_65_Football_API.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public int? HeadStaffID { get; set; }
        public virtual HeadStaff HeadStaff { get; set; }
        public int? AgentFee { get; set; }
        public int? PercentOwned { get; set; }
    }
}
