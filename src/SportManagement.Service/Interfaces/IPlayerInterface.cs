using SportManagement.Domain.Configurations.Pagination;
using SportManagement.Service.DTOs.Players;

namespace SportManagement.Service.Interfaces;

public interface IPlayerInterface
{
    Task<bool> DeleteAsync(int id);
    Task<PlayerForResultDto> GetByIdAsync(int id);
    Task<IEnumerable<PlayerForResultDto>> GetAllAsync(PaginationParams @params);
    Task<PlayerForResultDto> AddAsync(PlayerForCreationDto dto);
    Task<PlayerForResultDto> ModifyAsync(int id, PlayerForUpdateDto dto);
}
