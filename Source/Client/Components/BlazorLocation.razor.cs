namespace MyCostEstimator.Components
{
  using BlazorState.Services;
  using Microsoft.AspNetCore.Components;
  using MyCostEstimator.Features.Bases;

  public partial class BlazorLocation : BaseComponent
  {
    [Inject] public BlazorHostingLocation BlazorHostingLocation { get; set; }

    public string LocationName => BlazorHostingLocation.IsClientSide ? "Client Side" : "Server Side";
  }
}
