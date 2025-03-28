using SportManagement.Domain.Entities;
using SportManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Matches;

public class MatchForUpdateDto
{
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public DateTime MatchDate { get; set; }
    public MatchResult Result { get; set; }

}
