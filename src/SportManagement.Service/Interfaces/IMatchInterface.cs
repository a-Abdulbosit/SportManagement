using SportManagement.Service.DTOs.Matches;

namespace SportManagement.Service.Interfaces;

public interface IMatchInterface
{
    Task<bool> DeleteAsync(int id);
    Task<MatchForResultDto> GetByIdAsync(int id);
    Task<IEnumerable<MatchForResultDto>> GetAllAsync();
    Task<MatchForResultDto> AddAsync(MatchForCreationDto dto);
    Task<MatchForResultDto> ModifyAsync(int id, MatchForUpdateDto dto);
}
