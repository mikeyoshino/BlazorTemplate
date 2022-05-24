namespace MyCostEstimator.Models
{
  using System;

  public class User : BaseId
  {
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public UserRole UserRole { get; set; }
    public Guid UserRoleId { get; set; }
  }
}
