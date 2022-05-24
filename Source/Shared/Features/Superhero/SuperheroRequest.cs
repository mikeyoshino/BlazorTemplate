namespace MyCostEstimator.Features.Superheros
{
  using ProtoBuf;

  [ProtoContract]
  public class SuperheroRequest
  {
    [ProtoMember(1)]
    public int NumberOfHero { get; set; }
  }
}
