using SportManagement.Domain.Common;
using SportManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Domain.Entities
{
    public class Team : Auditable
    {
        public string TeamName { get; set; } 
        public string Coach { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
