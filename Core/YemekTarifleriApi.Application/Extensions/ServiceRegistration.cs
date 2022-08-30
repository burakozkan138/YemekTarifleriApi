using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace YemekTarifleriApi.Application.Extensions;

public static class ServiceRegistration
{
  public static void AddApplicationServices(this IServiceCollection serviceCollection)
  {
    var assembly = Assembly.GetExecutingAssembly();
    serviceCollection.AddMediatR(assembly);
    serviceCollection.AddAutoMapper(assembly);
  }
}