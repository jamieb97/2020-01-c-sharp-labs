using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Football_Database
{
    class Owner
    {
        public int ClubID { get; set; }

        [Required]
        public string ClubName { get; set; }

        public int? NetWorth { get; set; }
    }
}
