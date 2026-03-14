namespace TextAdventure;

internal static class Choices
{
    public static void FirstChoice()
    {
        bool validChoice = false;
        Console.WriteLine("You are in the forest. You can go either to the east or west.");
        while (!validChoice)
        {
            Console.WriteLine("What do you choose?");
            Console.WriteLine("1. East");
            Console.WriteLine("2. West");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    Console.WriteLine("You fall off a cliff and die.");
                    Console.WriteLine("Game Over.");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    Console.WriteLine("You exit the forest and see the castle.\n");
                    validChoice = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose between 1 and 2.\n");
                    break;
            }
        }
    }
}
