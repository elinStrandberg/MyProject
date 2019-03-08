using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        public const int gameBoardX = 20;
        public const int gameBoardY = 5;
        Player player;
        Room[,] world;
        public static Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();
                EncounterRoom();
            } while (player.Health > 0 && Monster.NumberOfMonsters > 0);

            if (Monster.NumberOfMonsters == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                TextUtils.AnimateText($"You are the chosen defender of the realm great champion..!\nThe kingdom is finally at peace from the scary monsters. \nLong live {player.Name} the queen!", 100);
                Console.ReadKey(true);
                Console.ResetColor();
            }
            GameOver();
        }

        private void EncounterRoom()
        {
            if (world[player.X, player.Y].Item is Item)
                PickUpItem();
            else if (world[player.X, player.Y].Monster is Monster)
                FightMonster();
        }

        private void FightMonster()
        {
            var playerPosition = world[player.X, player.Y];

            Console.WriteLine($"\n\nYou encountered {playerPosition.Monster.Name}, a {playerPosition.Monster}. \nHis health is: {playerPosition.Monster.Health}");

            player.Attack(playerPosition.Monster);
            Console.WriteLine($"You hit him for {player.Damage}, his health is now {playerPosition.Monster.Health}");
            playerPosition.Monster.Attack(player);
            Console.ReadKey();

            if (playerPosition.Monster.Health <= 0)
            {
                player.Inventory.Backpack.Add(playerPosition.Monster);
                playerPosition.Monster = null;
                Monster.NumberOfMonsters--;
            }
        }

        private void PickUpItem() // kollar rummet där spelarens x och y värdet är sedan kollar den om det är ett item som är egenskapen hos vår klass. 
        {
            Room playerPosition = world[player.X, player.Y];

            player.Inventory.Backpack.Add(playerPosition.Item);

            if (playerPosition.Item is IAttackable)
            {
                //player.Attack(playerPosition.Item.) //här vill vi attackera kistan, men det funkar inte
            }

            if (playerPosition.Item is Item) //ökar hälsan med 10 för varje item vi plockar upp
            {
                playerPosition.Item.ModifyPlayer(player);
            }
            playerPosition.Item = null;
        }

        public void CreatePlayer()
        {
            player = new Player(300, RandomUtils.RandomGenerator(0, gameBoardX), RandomUtils.RandomGenerator(0, gameBoardY), "Bob");

            player.Inventory = new Inventory();
            player.Inventory.Backpack = new List<IPackable>(); //skapar en ny lista
        }

        private void CreateWorld()
        {
            world = new Room[gameBoardX, gameBoardY];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    //int percentage = RandomUtils.RandomGenerator(0, 100);
                    //int percentage = random.Next(0, 100);
                    //if (percentage < 10)
                    //    world[x, y].Monster = new Skeleton(30, "Joe");
                    //else if (percentage < 15)
                    //    world[x, y].Monster = new WhiteWalker(50, "Larry");
                    //else if (percentage < 20)
                    //    world[x, y].Item = new Sword("Sword", 1, 1);
                    //else if (percentage < 25)
                    //    world[x, y].Item = new Apple("Golden Apple", 200, 0);
                    if (!(player.X == x && player.Y == y))
                    {
                        if (RandomUtils.CheckPercentage(5))
                        {
                            world[x, y].Monster = new Skeleton(30, "Joe Skellington");
                        }
                        else if (RandomUtils.CheckPercentage(5))
                        {
                            world[x, y].Monster = new WhiteWalker(50, "Larry Vandraren");
                        }
                        else if (RandomUtils.CheckPercentage(5))
                            world[x, y].Item = new Sword("Sword", 1, 1);
                        else if (RandomUtils.CheckPercentage(5))
                            world[x, y].Item = new Apple("Golden Apple", 200, 0);
                        else if (RandomUtils.CheckPercentage(5))
                            world[x, y].Item = new Chest("Treasure Chest", 100, 5);
                    }
                }
            }
            //player.Money = 6789;
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write("P");
                    else if (room.Monster != null)
                        Console.Write("M");
                    else if (room.Item != null)
                        Console.Write("I");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Name: {player.Name}");

            Console.WriteLine($"Strength: {player.Strength}");
            Console.WriteLine($"Monsters remaining: {Monster.NumberOfMonsters}");

            foreach (var item in player.Inventory.Backpack)
            {
                Console.WriteLine($"You picked up {item.Name}");
            }
        }

        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
                //player.Health--; //minskar hälsan för varje steg
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.WriteLine("Do you want to play again? Press y.");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Play();
            }
        }
    }
}
