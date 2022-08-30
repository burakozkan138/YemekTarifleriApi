using Microsoft.Extensions.Configuration;

namespace YemekTarifleriApi.Persistence.Config;

public static class DatabaseConfiguration
{
  public static string GetConnectionString()
  {
    ConfigurationManager configurationManager = new ConfigurationManager();
    configurationManager.SetBasePath(Directory.GetCurrentDirectory());
    configurationManager.AddJsonFile("appsettings.json");

    return configurationManager.GetConnectionString("PostgreSQL");
  }
}