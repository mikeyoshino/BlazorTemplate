namespace MyCostEstimator.Models
{
  using System.Collections.Generic;

  public class UserRole : BaseId
  {
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
  }
}
