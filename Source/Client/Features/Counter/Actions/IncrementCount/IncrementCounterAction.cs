namespace MyCostEstimator.Features.Counters
{
  using MyCostEstimator.Features.Bases;

  internal partial class CounterState
  {
    public class IncrementCounterAction : BaseAction
    {
      public int Amount { get; set; }
    }
  }
}
