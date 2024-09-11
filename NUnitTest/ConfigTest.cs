using NUnit.Framework;
using AdventureGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class ConfigTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateConfigDataTest()
        {
            ConfigData configData = Config.ConvertJsonToConfigData();
            Assert.That(configData != null);
            Assert.That(configData.Configurations != null);
        }

        [Test]
        public void CreateConfigTest() {
            Config config = Config.LoadConfig("easy");
            Assert.That(config != null);
            Assert.That(config.coinMultiplier == 1);
            Assert.That(config.monsterDamagePercentage == 0.25);
            Assert.That(config.scoreMultiplier == 1);
        }
    }
}