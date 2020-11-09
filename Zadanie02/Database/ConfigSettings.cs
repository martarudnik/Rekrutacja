using Microsoft.Extensions.Configuration;
using System.IO;

namespace Zadanie02.Database
{
    public static class ConfigSettings
    {
        public static string ConnectionString { get; set; }
        static ConfigSettings()
        {

            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            ConnectionString = configurationBuilder.Build().GetSection("ConnectionStrings:Default").Value;

        }
    }
}
