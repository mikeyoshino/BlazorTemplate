namespace MyCostEstimator.Features.EventStreams
{
  using MyCostEstimator.Features.Bases;

  internal partial class EventStreamState
  {
    public class AddEventAction : BaseAction
    {
      public string Message { get; set; }
    }
  }
}
