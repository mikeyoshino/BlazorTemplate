namespace MyCostEstimator.Pages
{
  using MyCostEstimator.Features.Bases;

  public partial class SettingsPage : BaseComponent
  {
    private const string RouteTemplate = "/Settings";

    public static string GetRoute() => RouteTemplate;
  }
}
