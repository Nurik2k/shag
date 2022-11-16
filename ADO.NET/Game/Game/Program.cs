using Game.DLL;
using Microsoft.IdentityModel.Tokens;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwitchMenu(Menu());
        }
        static int Menu()
        {
            Console.WriteLine("1.Add game");
            Console.WriteLine("2.Show games");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }
        static void SwitchMenu(int ch)
        {
            try
            {
                switch (ch) 
                {
                    case 1:
                        Console.Clear();
                        AddGame();
                        break;
                        case 2:
                        Console.Clear();
                        ShowGames();
                        break;

                }
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            }
        }

        private static void ShowGames()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (var game in games)
                {
                    Console.WriteLine($"ID - {game.Id}\nGame name - {game.GameName}\nDevelopers - {game.GameDeveloper}\nPublishYear - {game.PublishYear}\nStyle: \n{game.GameStyle}");
                    Console.WriteLine("_____________________________________________________________");
                }
                Console.ReadLine();
                Console.Clear();
                SwitchMenu(Menu());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void AddGame()
        {
            try
            {
                
                Model game = new Model();
                Console.Write("Enter name: ");
                game.GameName = Console.ReadLine();
                Console.Write("Enter dev: ");
                game.GameDeveloper = Console.ReadLine();
                Console.Write("Enter style: ");
                game.GameStyle = Console.ReadLine();
                Console.Write("Enter date: ");
                game.PublishYear = int.Parse(Console.ReadLine());
                using var db = new GameContext();
                db.Games.Add(game);
                db.SaveChanges();
                Console.WriteLine("Added!");
                Thread.Sleep(1500);
                SwitchMenu(Menu());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}