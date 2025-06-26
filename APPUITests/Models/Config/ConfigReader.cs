using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APPUITests.Models.Config
{
    public static class ConfigReader
    {
        public static AutoConfig Settings { get; private set; }

        public static void LoadConfig(string configFileCompletePath) {

            string json = File.ReadAllText(configFileCompletePath);
            Settings = JsonConvert.DeserializeObject<AutoConfig>(json);

            // Override with command line (TestContext) parameters if present
            var browserOverride = TestContext.Parameters["Browser"];
            var appUrlOverride = TestContext.Parameters["AppURL"];
            var envOverride = TestContext.Parameters["Environment"];

            if (!string.IsNullOrEmpty(browserOverride)) Settings.Browser = browserOverride;
            if (!string.IsNullOrEmpty(appUrlOverride)) Settings.AppURL = appUrlOverride;
            if (!string.IsNullOrEmpty(envOverride)) Settings.Environment = envOverride;

        }
      
    }
}
