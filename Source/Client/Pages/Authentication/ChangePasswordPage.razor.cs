namespace MyCostEstimator.Pages
{
  using MyCostEstimator.Features.Bases;

  public partial class ChangePasswordPage : BaseComponent
  {
    private const string RouteTemplate = "/changePassword";

    public static string GetRoute() => RouteTemplate;
  }
}
