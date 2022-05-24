namespace MyCostEstimator.Pages
{
  using BlazorState.Features.Routing;
  using System.Threading.Tasks;
  using MyCostEstimator.Features.Bases;
  using static MyCostEstimator.Features.Applications.ApplicationState;

  public partial class CounterPage : BaseComponent
  {
    private const string RouteTemplate = "/Counter";

    public static string GetRoute() => RouteTemplate;

    private async Task ButtonClick() =>
      await Send(new RouteState.ChangeRouteAction { NewRoute = "/" }).ConfigureAwait(false);

    private async Task ResetButtonClick() => await Send(new ResetStoreAction()).ConfigureAwait(false);
  }
}
