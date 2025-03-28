using SportManagement.Domain.Common;
using SportManagement.Domain.Enums;

namespace SportManagement.Domain.Entities;

public class User : Auditable
{
    public Role Role { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
