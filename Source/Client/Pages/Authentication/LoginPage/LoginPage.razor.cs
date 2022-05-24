namespace MyCostEstimator.Pages
{
  using MyCostEstimator.Features.Bases;

  public partial class LoginPage : BaseComponent
  {
    private const string RouteTemplate = "/Login";

    public static string GetRoute() => RouteTemplate;
  }
}
