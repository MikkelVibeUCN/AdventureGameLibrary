using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventureGameLibrary.GameHandler;

namespace AdventureGameLibrary
{
    public class Player : Character
    {
        private static string PlayerNamesFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("GameConsole\\bin\\Debug\\net8.0", "AdventureGameLibrary"), "JSON", "PlayerNames.json"); 
        private static Random random = new Random();
        public enum CharacterTypes
        {
            Warrior,
            Wizard,
            Thief
        }
        public CharacterTypes CharacterType { get; set; }
        public int ExperiencePoints { get; set; } = 1000;
        public Player(CharacterTypes CharacterType, Weapon? Weapon, string Name) : base(Name, Weapon, 0)
        {
            this.CharacterType = CharacterType;
        }
        public int Level { get { return ExperiencePoints / 1000; } }
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
            stringBuilder.Append($"Your character introduces himself as a level {Level} {CharacterType} with {Gold} gold ");
            if (Weapon == null)
                stringBuilder.Append("wielding no weapon");
            else
                stringBuilder.Append($"wielding a {Weapon.ToString()}");
            return stringBuilder.ToString();
        }
        public static Player CreatePlayer()
        {
            NamesData data = GetNameDataFromFilePath(PlayerNamesFilePath);

            Player.CharacterTypes characterType = (Player.CharacterTypes)random.Next(0, Enum.GetValues(typeof(Player.CharacterTypes)).Length);
            string name = data.Names[random.Next(0, data.Names.Length - 1)];

            return new Player(characterType, Weapon.CreateWeapon(), name);
        }
    }
}