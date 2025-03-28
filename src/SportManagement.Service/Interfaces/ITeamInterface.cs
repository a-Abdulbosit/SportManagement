using SportManagement.Service.DTOs.Teams;

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
