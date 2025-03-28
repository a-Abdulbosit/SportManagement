using SportManagement.Service.DTOs.Users;

namespace SportManagement.Service.Interfaces;

public interface IUserInterface
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync();
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
