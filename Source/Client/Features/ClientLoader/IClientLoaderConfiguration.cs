namespace MyCostEstimator.Features.ClientLoaders
{
  using System;

  public interface IClientLoaderConfiguration
  {
    TimeSpan DelayTimeSpan { get; }
  }
}
