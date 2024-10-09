using Microsoft.Extensions.Configuration;
using System.IO;

namespace TechShop.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TechShop.Helpers"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        public static string GetConnectionString(string name)
        {
            var configuration = GetConfiguration();
            return configuration.GetConnectionString(name);
        }
    }
}