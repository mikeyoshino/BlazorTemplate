namespace MyCostEstimator.Components
{
  using Microsoft.AspNetCore.Components;
  public interface IParentComponent
  {
    [Parameter] public RenderFragment ChildContent { get; set; }
  }
}
