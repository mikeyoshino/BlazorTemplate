namespace MyCostEstimator.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class Product : BaseId
  {
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }

  }
}
