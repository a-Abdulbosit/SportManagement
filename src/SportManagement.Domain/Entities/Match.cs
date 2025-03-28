using SportManagement.Domain.Common;
using SportManagement.Domain.Enums;

namespace SportManagement.Domain.Entities
{

    public class Match : Auditable
    {
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public DateTime MatchDate { get; set; }
        public MatchResult Result { get; set; }


        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
