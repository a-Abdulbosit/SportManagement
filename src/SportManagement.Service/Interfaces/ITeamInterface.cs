using SportManagement.Service.DTOs.Matches;
using SportManagement.Service.DTOs.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.Interfaces
{
    public interface ITeamInterface
    {
        Task<bool> DeleteAsync(int id);
        Task<TeamForResultDto> GetByIdAsync(int id);
        Task<IEnumerable<TeamForResultDto>> GetAllAsync();
        Task<TeamForResultDto> AddAsync(TeamForCreationDto dto);
        Task<TeamForResultDto> ModifyAsync(int id, TeamForUpdateDto dto);
    }
}
