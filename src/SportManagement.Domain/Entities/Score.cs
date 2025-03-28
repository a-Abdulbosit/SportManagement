using SportManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Domain.Entities
{

    public class Score : Auditable
    {

        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int Points { get; set; }

        public virtual Match Match { get; set; } 
        public virtual Player Player { get; set; }
    }
}
