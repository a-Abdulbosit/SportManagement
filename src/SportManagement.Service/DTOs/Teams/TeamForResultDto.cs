using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Teams;

public class TeamForResultDto
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public string Coach { get; set; }
    public virtual ICollection<PlayerForResultDto> Players { get; set; }
}
