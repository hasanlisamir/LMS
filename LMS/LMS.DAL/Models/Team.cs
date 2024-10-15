using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Models
{
    public class Team
    {
        [Range(1, 99)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Played { get; set; }
        public int Won { get; set; } 
        public int Drawn { get; set; } 
        public int Lost { get; set; } 
        public int GoalsFor { get; set; } 
        public int GoalsAgainst { get; set; } 
        public int Points { get; set; }
        [InverseProperty("HomeTeam")]
        public ICollection<Match> HostMatch { get; set; }
        [InverseProperty("AwayTeam")]
        public ICollection<Match> AwayMatch { get; set; }

    }
}
