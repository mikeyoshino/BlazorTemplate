namespace MyCostEstimator.Features.Counters.Components
{
  using System.Threading.Tasks;
  using MyCostEstimator.Components;
  using MyCostEstimator.Features.Bases;
  using static MyCostEstimator.Features.Counters.CounterState;

  public partial class Counter : BaseComponent, IAttributeComponent
  {
    protected async Task ButtonClick() => await Send(new IncrementCounterAction { Amount = 5 }).ConfigureAwait(false);
  }
}
