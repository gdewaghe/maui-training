namespace TextAdventure;

internal static class Choices
{
    public static void FirstChoice()
    {
        DisplayChoice(
            "You are in the forest. You can go either to the east or west.",
            "East",
            "West",
            "You exit the forest and see the castle.",
            "You fall off a cliff and die.");
    }

    private static void DisplayChoice(
        string choiceMessage,
        string firstChoice,
        string secondChoice,
        string validChoiceMessage,
        string invalidChoiceMessage)
    {
        bool validChoice = false;
        Console.WriteLine(choiceMessage);
        while (!validChoice)
        {
            Console.WriteLine("What do you choose?");
            Console.WriteLine($"1. {firstChoice}");
            Console.WriteLine($"2. {secondChoice}");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    Console.WriteLine(invalidChoiceMessage);
                    Console.WriteLine("Game Over.");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    Console.WriteLine($"{validChoiceMessage}\n");
                    validChoice = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose between 1 and 2.\n");
                    break;
            }
        }
    }
}
