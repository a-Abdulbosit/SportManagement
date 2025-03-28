using SportManagement.Domain.Common;

namespace SportManagement.Domain.Entities;

public class Player : Auditable
{
    public string PhotoPath { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
}
