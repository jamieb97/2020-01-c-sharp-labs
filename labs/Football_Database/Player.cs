using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Football_Database
{
    class Player
    {
        [StringLength(5)]
        public string PlayerID { get; set; }

        [Required]
        [StringLength(20)]
        public string PlayerName { get; set; }

        public int Age { get; set; }

        public uint? Salary { get; set; }

        public int AgentID { get; set; }

        public uint? ContractLegnth { get; set; }

        [StringLength(5)]
        public string? ClubID { get; set; }

    }
}
