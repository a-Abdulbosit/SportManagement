using Microsoft.AspNetCore.Http;
using SportManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Players;

public class PlayerForCreationDto
{
    public IFormFile Photo { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int TeamId { get; set; }
}
