namespace MyCostEstimator.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class Category : BaseId
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public ICollection<Product> Products { get; set; }
  }
}
