using Microsoft.Extensions.DependencyInjection;
using YemekTarifleriApi.Application.Services;
using YemekTarifleriApi.Infrastructure.Services;

namespace YemekTarifleriApi.Infrastructure.Extensions;

public static class ServiceRegistration
{
  public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
    serviceCollection.AddScoped<IPasswordHandler, PasswordHandler>();
  }
}