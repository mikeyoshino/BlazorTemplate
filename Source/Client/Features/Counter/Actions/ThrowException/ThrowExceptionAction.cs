namespace MyCostEstimator.Features.Counters
{
  using MyCostEstimator.Features.Bases;

  internal partial class CounterState
  {
    public class ThrowExceptionAction : BaseAction
    {
      public string Message { get; set; }
    }
  }
}
