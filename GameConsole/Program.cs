using AdventureGameLibrary;
using Newtonsoft.Json.Bson;
using System.Data;
namespace GameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string difficulty = ChooseDifficulty();

            GameHandler gameHandler = new GameHandler(difficulty);

            gameHandler.StartGame();

            PlayGame(gameHandler);
        }

        private static void PlayGame(GameHandler gameHandler)
        {
            IntroMessage(gameHandler);
            Console.WriteLine("Press any key to hit");
            Console.ReadLine();

            gameHandler.MonsterDeath += (sender, e) => MonsterDiedDialog(gameHandler);
            while (gameHandler.IsPlayerAlive())
            {
                gameHandler.StepGame();
                PrintStatus(gameHandler);

                Console.ReadLine();
            }
            Console.WriteLine($"You died total score: {gameHandler.score}");
        }

        private static void MonsterDiedDialog(GameHandler gameHandler)
        {
            Console.WriteLine("The monster died");
            IntroMessage(gameHandler);
        }
        private static string ChooseDifficulty()
        {
            int difficultyInt = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Welcome to the adventure game! Please choose a difficulty from easy to impossible by typing a number between 0-3.");

                string difficultyInput = Console.ReadLine();

                if (int.TryParse(difficultyInput, out _))
                {
                    difficultyInt = int.Parse(difficultyInput);
                    if (difficultyInt < 4 && difficultyInt >= 0)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, has to be between 0-3");
                    }
                }
                else
                {
                    Console.WriteLine("Not a number");
                }
            }
            return ParseDifficultyToString(difficultyInt);
        }

        private static void IntroMessage(GameHandler gameHandler)
        {
            Console.WriteLine(gameHandler.Player.ToString() + ". " + gameHandler.Monster.ToString());
        }

        private static void PrintStatus(GameHandler gameHandler)
        {
            Console.WriteLine($"You have {gameHandler.Player.HitPoints} health left the monster has {gameHandler.Monster.HitPoints}");
        }
        private static string ParseDifficultyToString(int input)
        {
            switch (input)
            {
                case 0:
                    return "easy";
                case 1:
                    return "medium";
                case 2:
                    return "hard";
                case 3:
                    return "impossible";
                default:
                    return "easy";
            }
        }
    }
}
