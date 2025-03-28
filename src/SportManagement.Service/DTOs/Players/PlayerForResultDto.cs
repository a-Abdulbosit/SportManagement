using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Players;

public class PlayerForResultDto
{
    public string PhotoPath { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public int TeamId { get; set; }

}
