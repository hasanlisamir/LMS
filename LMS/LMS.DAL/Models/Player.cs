using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int JerseyNumber { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public int Goals { get; set; }
    }
}
