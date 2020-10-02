using Microsoft.Extensions.Configuration;
using System;

namespace DAS.Utility
{
    public static class ConfigUtils
    {
        public static string GetConnectionString(string key)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString(key);
        }
    }

}
