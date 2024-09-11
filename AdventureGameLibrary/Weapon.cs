using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameLibrary
{
    public class Weapon
    {
        private static Random Random = new Random();
        private const int MinDamage = 1;
        private static string WeeaponNamesFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("GameConsole\\bin\\Debug\\net8.0", "AdventureGameLibrary"), "JSON", "Weapons.json"); 
        public string Name { get; }
        public int MaxDamage { get; }
        public Weapon(string Name, int MaxDamage)
        {
            this.Name = Name;
            this.MaxDamage = MaxDamage;
        }
        public int Attack()
        {
            return Random.Next(MinDamage, MaxDamage);
        }
        override public string ToString()
        {
            return $"{Name} with a maximum damage of {MaxDamage}";
        }
        public static Weapon CreateWeapon()
        {
            string json = File.ReadAllText(WeeaponNamesFilePath);
            List<Weapon> weapons = JsonConvert.DeserializeObject<WeaponData>(json).Weapons;

            return weapons[Random.Next(0, weapons.Count - 1)];
        }
        public class WeaponData
        {
            public List<Weapon> Weapons { get; set; }
        }
    }
}