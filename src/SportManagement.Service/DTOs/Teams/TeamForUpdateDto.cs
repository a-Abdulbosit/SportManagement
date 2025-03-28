using SportManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.DTOs.Teams
{
    public class TeamForUpdateDto
    {
        public string TeamName { get; set; }
        public string Coach { get; set; }
    }
}
