namespace MyCostEstimator.Client.Integration.Tests.Infrastructure
{
  using System;
  using MyCostEstimator.Features.ClientLoaders;

  [NotTest]
  public class ClientLoaderTestConfiguration : IClientLoaderConfiguration
  {
    public TimeSpan DelayTimeSpan => TimeSpan.FromMilliseconds(10);
  }
}
