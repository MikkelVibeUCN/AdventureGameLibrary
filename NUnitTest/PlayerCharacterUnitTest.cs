using AdventureGameLibrary;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace NUnitTest
{
    public class PlayerCharacterUnitTest
    {
        private int maxDamage = 40;
        private Player playerCharacter;

        [SetUp]
        public void Setup() 
        {
            playerCharacter = new Player(Player.CharacterTypes.Wizard, new Weapon("Staff", maxDamage), "John");
        }

        [Test]
        public void PropertiesSavedCorrectlyInConstructor()
        {
            Assert.That(playerCharacter.Name.Equals("John"));
            if(playerCharacter.Weapon != null)
                Assert.That(maxDamage == playerCharacter.Weapon.MaxDamage);
        }

        [Test]
        public void AssertDefaultValues()
        {
            Assert.That(playerCharacter.HitPoints == 20);
            Assert.That(playerCharacter.Gold == 0);
        }

        [Test]
        public void IsAliveTest()
        {
            Assert.That(playerCharacter.IsAlive);
            playerCharacter.HitPoints = 0;
            Assert.That(!playerCharacter.IsAlive);
        }

        [Test]
        public void AttackTest()
        {
            bool AttackInRange = true;
            int i = 0;
            while(i++ < 1001 && AttackInRange)
            {
                int attack = playerCharacter.Attack();
                if (attack > maxDamage || attack < 1)
                {
                    AttackInRange = false;
                }
            }
            Assert.That(AttackInRange);

            Player playerCharacter2 = new Player(Player.CharacterTypes.Warrior, null, "John");
            Assert.That(playerCharacter2.Attack() == 0);
        }

        [Test]
        public void LevelTest()
        {
            playerCharacter.ExperiencePoints = 999;
            Assert.That(playerCharacter.Level == 0);

            playerCharacter.ExperiencePoints = 1000;
            Assert.That(playerCharacter.Level == 1);

            playerCharacter.ExperiencePoints = 1001;
            Assert.That(playerCharacter.Level == 1);

        }
    }
}