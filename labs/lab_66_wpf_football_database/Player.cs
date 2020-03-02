using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_66_wpf_football_database
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int? AgentID { get; set; }
        public virtual Agent Agent { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int ContractLength { get; set; }
        public int? OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
