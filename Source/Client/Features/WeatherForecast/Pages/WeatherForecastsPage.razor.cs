namespace MyCostEstimator.Pages
{
  using System.Threading.Tasks;
  using MyCostEstimator.Features.Bases;
  using static MyCostEstimator.Features.WeatherForecasts.WeatherForecastsState;

  public partial class WeatherForecastsPage : BaseComponent
  {
    private const string RouteTemplate = "/WeatherForecasts";

    public static string GetRoute() => RouteTemplate;

    protected override async Task OnInitializedAsync() =>
      await Send(new FetchWeatherForecastsAction()).ConfigureAwait(false);
  }
}
