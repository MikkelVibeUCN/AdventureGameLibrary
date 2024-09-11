using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameLibrary
{
    public class GameHandler
    {
        public event EventHandler MonsterDeath;
        private Random random = new Random();

        private Config difficultyConfig;
        public double score { get; private set; }
        public Player Player { get; private set; }
        public Monster Monster { get; private set; }
         
        public GameHandler(string difficulty)
        {
            difficultyConfig = Config.LoadConfig(difficulty);
        }

        public void StartGame()
        {
            this.Player = Player.CreatePlayer();
            this.Monster = Monster.CreateMonster();
        }
        public void StepGame()
        {
            Monster.HitPoints -= Player.Attack();

            if (Monster.IsAlive)
            {
                Player.HitPoints -= (int) (Monster.Attack() * difficultyConfig.monsterDamagePercentage);
            }
            else
            {
                Player.Gold += Monster.Gold * difficultyConfig.coinMultiplier;
                Player.ExperiencePoints += 50;
                score += 50 * difficultyConfig.scoreMultiplier + Monster.Gold * 10 * difficultyConfig.scoreMultiplier;
                this.Monster = Monster.CreateMonster();
                OnMonsterDeath(EventArgs.Empty);
            }
        }
        public bool IsMonsterAlive()
        {
            return Monster.IsAlive;
        }
        public bool IsPlayerAlive()
        {
            return Player.IsAlive;
        }

        protected virtual void OnMonsterDeath(EventArgs e)
        {
            MonsterDeath?.Invoke(this, e);
        }
    }
}