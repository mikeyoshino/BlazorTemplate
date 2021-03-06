namespace MyCostEstimator.Features.Bases
{
  using BlazorState.Pipeline.ReduxDevTools;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using MyCostEstimator.Components;
  using MyCostEstimator.Features.Applications;
  using MyCostEstimator.Features.Counters;
  using MyCostEstimator.Features.EventStreams;
  using MyCostEstimator.Features.Superheros;
  using MyCostEstimator.Features.WeatherForecasts;

  /// <summary>
  /// Makes access to the State a little easier and by inheriting from
  /// BlazorStateDevToolsComponent it allows for ReduxDevTools operation.
  /// </summary>
  /// <remarks>
  /// In production one would NOT be required to use these base components
  /// But would be required to properly implement the required interfaces.
  /// one could conditionally inherit from BaseComponent for production build.
  /// </remarks>
  public class BaseComponent : BlazorStateDevToolsComponent, IAttributeComponent
  {

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    internal ApplicationState ApplicationState => GetState<ApplicationState>();
    internal CounterState CounterState => GetState<CounterState>();
    internal EventStreamState EventStreamState => GetState<EventStreamState>();
    internal WeatherForecastsState WeatherForecastsState => GetState<WeatherForecastsState>();
    internal SuperheroState SuperheroState => GetState<SuperheroState>();
    protected Task<TResponse> Send<TResponse>(IRequest<TResponse> aRequest) => Send(aRequest);

    protected async Task Send(IRequest aRequest) => await Mediator.Send(aRequest).ConfigureAwait(false);
  }
}
