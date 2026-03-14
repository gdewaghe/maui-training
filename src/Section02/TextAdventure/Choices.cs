namespace TextAdventure;

internal static class Choices
{
    public static void Start()
    {
        DisplayChoice(
            "You are in the forest. You can go either to the east or west.",
            "East",
            "West",
            "You exit the forest and see the castle.",
            "You fall off a cliff and die.");

        DisplayChoice(
            "You are in front of the castle. You can enter either though the door or through the window.",
            "Door",
            "Window",
            "You managed to enter the castle.",
            "A guard arrests you.");

        Console.WriteLine("Congratulations! You have completed the adventure.");
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
