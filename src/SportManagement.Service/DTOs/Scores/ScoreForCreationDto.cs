using SportManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Scores;

public class ScoreForCreationDto
{
    public int MatchId { get; set; }
    public int PlayerId { get; set; }
    public int Points { get; set; }

}
