using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public string HomeTeamScoredPlayers { get; set; } = "NONE";
        public string AwayTeamScoredPlayers { get; set; } = "NONE";
    }
}
