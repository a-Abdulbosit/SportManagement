using SportManagement.Domain.Enums;

namespace SportManagement.Service.DTOs.Users;

public class UserForResultDto
{
    public int Id { get; set; }
    public Role Role { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
