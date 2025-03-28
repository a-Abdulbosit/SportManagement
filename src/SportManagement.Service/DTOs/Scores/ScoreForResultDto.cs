using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Matches;
using SportManagement.Service.DTOs.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Scores
{
    public class ScoreForResultDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int Points { get; set; }

        public virtual PlayerForResultDto Player { get; set; }
    }
}
