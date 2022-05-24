namespace MyCostEstimator.Server
{
  using Microsoft.AspNetCore.Hosting;


  using Microsoft.Extensions.Hosting;
  using MyCostEstimator.Features.Superheros;

  public class Program
  {
    public static IHostBuilder CreateHostBuilder(string[] aArgumentArray) =>
      Host.CreateDefaultBuilder(aArgumentArray)
        .ConfigureWebHostDefaults
        (
          aWebHostBuilder =>
          {
            #region UseHttpSys
            // The default is kestrel
            #endregion
            aWebHostBuilder.UseStaticWebAssets();
            aWebHostBuilder.UseStartup<Startup>();
          }
        );

    public static void Main(string[] aArgumentArray)
    {
      var schemaGenerator = new ProtoBuf.Grpc.Reflection.SchemaGenerator
      {
        ProtoSyntax = ProtoBuf.Meta.ProtoSyntax.Proto3
      };

      string schema = schemaGenerator.GetSchema<ISuperheroService>();
      System.IO.Directory.CreateDirectory("protos");
      System.IO.File.WriteAllText("protos/superherocservice.proto", schema);

      CreateHostBuilder(aArgumentArray).Build().Run();
    }
  }
}
