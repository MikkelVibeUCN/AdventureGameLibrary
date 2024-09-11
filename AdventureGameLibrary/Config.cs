using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameLibrary
{
    public class Config
    {
        private const string ConfigFilePath = "C:\\Users\\mikvc\\source\\repos\\AdventureGameLibrary\\AdventureGameLibrary\\JSON\\Config.json";
        public float monsterDamagePercentage { get; set; }
        public int coinMultiplier { get; set; }
        public float scoreMultiplier { get; set; }

        public static Config LoadConfig(string difficulty)
        {
            ConfigData configData = ConvertJsonToConfigData();

            if (configData.Configurations.TryGetValue(difficulty, out Config difficultyConfig))
                return difficultyConfig;
            else
                return null;
        }
        public static ConfigData ConvertJsonToConfigData()
        {
            string json = File.ReadAllText(ConfigFilePath);
           
            return JsonConvert.DeserializeObject<ConfigData>(json);
        }
    }
    public class ConfigData
    {
        public Dictionary<string, Config> Configurations { get; set; }
    }

}