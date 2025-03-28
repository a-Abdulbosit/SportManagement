using SportManagement.Service.DTOs.Scores;

namespace SportManagement.Service.Interfaces;

public interface IScoreInterFace
{
    Task<bool> DeleteAsync(int id);
    Task<ScoreForResultDto> GetByIdAsync(int id);
    Task<IEnumerable<ScoreForResultDto>> GetAllAsync();
    Task<ScoreForResultDto> AddAsync(ScoreForCreationDto dto);
    Task<ScoreForResultDto> ModifyAsync(int id, ScoreForUpdateDto dto);
}
