using AdventureGameLibrary;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using Newtonsoft.Json.Linq;

namespace NUnitTest
{
    public class MoonsterUnitTest
    {
        private int maxDamage = 40;
        private Monster monster;

        [SetUp]
        public void Setup()
        {
            monster = new Monster(Monster.MonsterTypes.Goblin, "Benny", new Weapon("Gun", maxDamage));
        }

        [Test]
        public void PropertiesSavedCorrectlyInConstructor()
        {
            Assert.That(monster.Name.Equals("Benny"));
            if(monster.Weapon != null) 
                Assert.That(maxDamage == monster.Weapon.MaxDamage);

            Assert.That(Monster.MonsterTypes.Goblin == monster.MonsterType);
        }

        [Test]
        public void AssertDefaultValues()
        {
            int maxGold = 25;
            bool GoldInRange = true;
            int i = 0;
            while (i++ < 1001 && GoldInRange)
            {
                monster = new Monster(Monster.MonsterTypes.Goblin, "Benny", null);
                if (monster.Gold > maxGold || monster.Gold < 1)
                {
                    GoldInRange = false;
                }
            }
            Assert.That(GoldInRange);

            Assert.That(monster.HitPoints == 20);
        }

        [Test]
        public void IsAliveTest()
        {
            Assert.That(monster.IsAlive);
            monster.HitPoints = 0;
            Assert.That(!monster.IsAlive);
        }

        [Test]
        public void AttackTest()
        {
            bool AttackInRange = true;
            int i = 0;
            while (i++ < 1001 && AttackInRange)
            {
                int attack = monster.Attack();
                if (attack > maxDamage || attack < 1)
                {
                    AttackInRange = false;
                }
            }
            Assert.That(AttackInRange);

            Monster monster2 = new Monster(Monster.MonsterTypes.Goblin, "Benny", null);
            Assert.That(monster2.Attack() == 0);
        }
    }
}