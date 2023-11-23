using UI;

namespace Program;

internal static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string input = ConsoleMenu.commands();
            int returnFromUserInput = ConsoleMenu.userInput(input);
            while (returnFromUserInput != 1)
            {
                input = ConsoleMenu.commands();
                returnFromUserInput = ConsoleMenu.userInput(input);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}