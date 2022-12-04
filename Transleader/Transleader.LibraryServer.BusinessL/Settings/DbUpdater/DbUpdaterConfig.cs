using Microsoft.Extensions.Configuration;

namespace Transleader.LibraryServer.BusinessL.Settings.DbUpdater
{
    public class DbUpdaterConfig
    {
        private IConfiguration _configuration;

        public DbUpdaterConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            LaunchOptions = new LaunchOptions();
            _configuration.GetSection(LaunchOptions.Launch).Bind(LaunchOptions);
        }

        public LaunchOptions LaunchOptions { get; set; }

        public void ReloadFile()
        {
            string path = "dbUpdaterConfig.json";

            using (var file = File.Open(path, FileMode.Open))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write(ToString());
                }
            }
        }

        public override string ToString()
        {
            return "{\n" + $"\t\"{LaunchOptions.Launch}\": {LaunchOptions}" + "\n}";
        }
    }
}
