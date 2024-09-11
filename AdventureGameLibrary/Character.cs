using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventureGameLibrary.GameHandler;

namespace AdventureGameLibrary
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int HitPoints { get; set; } = 20;
        public int Gold { get; set; }
        public Weapon? Weapon { get; }
        public Character(string Name, Weapon? Weapon, int gold)
        {
            this.Name = Name;
            this.Weapon = Weapon;
            this.Gold = gold;
        }
        public bool IsAlive { get { return HitPoints > 0; } }

        protected static NamesData GetNameDataFromFilePath(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<NamesData>(jsonContent);
        }
        public class NamesData
        {
            public string[] Names { get; set; }
        }
    }
}