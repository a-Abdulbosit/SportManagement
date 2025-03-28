using SportManagement.Domain.Entities;
using SportManagement.Domain.Enums;
using SportManagement.Service.DTOs.Scores;
using SportManagement.Service.DTOs.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Matches;

public class MatchForResultDto
{
    public int Id { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public DateTime MatchDate { get; set; }
    public MatchResult Result { get; set; }


    public virtual TeamForResultDto Team1 { get; set; }
    public virtual TeamForResultDto Team2 { get; set; }
    public virtual ICollection<ScoreForResultDto> Scores { get; set; }
}
