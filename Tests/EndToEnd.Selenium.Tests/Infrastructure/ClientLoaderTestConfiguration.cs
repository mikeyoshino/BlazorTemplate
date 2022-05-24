namespace MyCostEstimator.EndToEnd.Tests.Infrastructure
{
  using System;
  using MyCostEstimator.Features.ClientLoaders;

  public class TestClientLoaderConfiguration : IClientLoaderConfiguration
  {
    public TimeSpan DelayTimeSpan => TimeSpan.FromMilliseconds(10);
  }
}
