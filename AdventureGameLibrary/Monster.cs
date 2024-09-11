using static AdventureGameLibrary.Player;
using System.Reflection.Emit;
using System.Text;
using System;

namespace AdventureGameLibrary
{
    public class Monster : Character
    {
        public event EventHandler MonsterDeath;
        private static Random random = new Random();
        private const string MonsterNamesFilePath = "C:\\Users\\mikvc\\source\\repos\\AdventureGameLibrary\\AdventureGameLibrary\\JSON\\MonsterNames.json";
        public enum MonsterTypes
        {
            Orc,
            Ogre,
            Goblin,
            Troll
        }
        public MonsterTypes MonsterType { get; set; }
        
        public Monster(MonsterTypes MonsterType, string Name, Weapon Weapon) : base(Name, Weapon, random.Next(1, 25))
        {
            this.MonsterType = MonsterType;
        }
        public int Attack()
        {
            if (Weapon == null)
                return 0;
            else
                return Weapon.Attack();
        }

        override public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"I'm a {MonsterType}. My name is {Name}. I have {HitPoints} health, I am ");
            if (Weapon == null)
                stringBuilder.Append("wielding no weapon");
            else
                stringBuilder.Append($"wielding a {Weapon.ToString()}");
            return stringBuilder.ToString();
        }
        public static Monster CreateMonster()
        {
            NamesData data = GetNameDataFromFilePath(MonsterNamesFilePath);

            Monster.MonsterTypes monsterType = (Monster.MonsterTypes)random.Next(0, Enum.GetValues(typeof(Monster.MonsterTypes)).Length);
            string name = data.Names[random.Next(0, data.Names.Length)];

            return new Monster(monsterType, name, Weapon.CreateWeapon());
        }
    }
}