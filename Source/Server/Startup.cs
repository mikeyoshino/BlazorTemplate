namespace MyCostEstimator.Server
{
  using AutoMapper;
  using FluentValidation.AspNetCore;
  using MediatR;
  using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Microsoft.OpenApi.Models;
  using ProtoBuf.Grpc.Server;
  using Swashbuckle.AspNetCore.Swagger;
  using System;
  using System.IO;
  using System.Linq;
  using System.Net.Http;
  using System.Net.Mime;
  using System.Reflection;
  using MyCostEstimator.Configuration;
  using MyCostEstimator.Features.Bases;
  using MyCostEstimator.Features.Superheros;
  using MyCostEstimator.Infrastructure;
  using MyCostEstimator.Data;
  using Microsoft.EntityFrameworkCore;

  public class Startup
  {
    private const string SwaggerVersion = "v1";
    private readonly IConfiguration Configuration;
    private string SwaggerApiTitle => $"MyCostEstimator API {SwaggerVersion}";
    private string SwaggerEndPoint => $"/swagger/{SwaggerVersion}/swagger.json";

    public Startup(IConfiguration aConfiguration)
    {
      Configuration = aConfiguration;
    }

    public void Configure
    (
      IApplicationBuilder aApplicationBuilder,
      IWebHostEnvironment aWebHostEnvironment
    )
    {
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      aApplicationBuilder.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      aApplicationBuilder.UseSwaggerUI
      (
        aSwaggerUIOptions => aSwaggerUIOptions.SwaggerEndpoint(SwaggerEndPoint, SwaggerApiTitle)
      );

      aApplicationBuilder.UseResponseCompression();

      if (aWebHostEnvironment.IsDevelopment())
      {
        aApplicationBuilder.UseDeveloperExceptionPage();
        aApplicationBuilder.UseWebAssemblyDebugging();
      }

      aApplicationBuilder.UseRouting();
      aApplicationBuilder.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });
      aApplicationBuilder.UseEndpoints
      (
        aEndpointRouteBuilder =>
        {
          aEndpointRouteBuilder.MapGrpcService<SuperheroService>();
          aEndpointRouteBuilder.MapCodeFirstGrpcReflectionService();
          aEndpointRouteBuilder.MapControllers();
          aEndpointRouteBuilder.MapBlazorHub();
          aEndpointRouteBuilder.MapFallbackToPage("/_Host");
        }
      );
      aApplicationBuilder.UseStaticFiles();
      aApplicationBuilder.UseBlazorFrameworkFiles();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection)
    {
      ConfigureSettings(aServiceCollection);
      aServiceCollection.AddAutoMapper(typeof(MappingProfile).Assembly);
      aServiceCollection.AddRazorPages();
      aServiceCollection.AddServerSideBlazor();
      aServiceCollection.AddCodeFirstGrpc();
      aServiceCollection.AddCodeFirstGrpcReflection();
      aServiceCollection.AddDbContext<SqlContext>(aDbContextOptionsBuilder => aDbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      aServiceCollection.AddMvc()
        .AddFluentValidation
        (
          aFluentValidationMvcConfiguration =>
          {
            aFluentValidationMvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>();
            aFluentValidationMvcConfiguration.RegisterValidatorsFromAssemblyContaining<BaseRequest>();
          }
        );

      aServiceCollection.Configure<ApiBehaviorOptions>
      (
        aApiBehaviorOptions => aApiBehaviorOptions.SuppressInferBindingSourcesForParameters = true);

      aServiceCollection.AddResponseCompression
      (
        aResponseCompressionOptions =>
          aResponseCompressionOptions.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat
          (
            new[] { MediaTypeNames.Application.Octet }
          )
      );

      Client.Program.ConfigureServices(aServiceCollection);

      aServiceCollection.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

      ConfigureSwagger(aServiceCollection);
    }

    private void ConfigureSettings(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddOptions();
      aServiceCollection.Configure<SampleOptions>(Configuration.GetSection(nameof(SampleOptions)));
    }

    private void ConfigureSwagger(IServiceCollection aServiceCollection)
    {
      // Register the Swagger generator, defining 1 or more Swagger documents
      aServiceCollection.AddSwaggerGen
        (
          aSwaggerGenOptions =>
          {
            aSwaggerGenOptions
            .SwaggerDoc
            (
              SwaggerVersion,
              new OpenApiInfo { Title = SwaggerApiTitle, Version = SwaggerVersion }
            );
            aSwaggerGenOptions.EnableAnnotations();

            // Set the comments path for the Swagger JSON and UI from Server.
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            aSwaggerGenOptions.IncludeXmlComments(xmlPath);

            // Set the comments path for the Swagger JSON and UI from API.
            xmlFile = $"{typeof(BaseRequest).Assembly.GetName().Name}.xml";
            xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            aSwaggerGenOptions.IncludeXmlComments(xmlPath);
          }
        );

      aServiceCollection.AddFluentValidationRulesToSwagger();
    }
  }
}
