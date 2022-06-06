namespace Mate.Drawing;


public static class ConsoleExtensions
{

    public static void Write(
        string message, 
        ConsoleColor foreground,
        ConsoleColor background)
    {
        var oldForeground = Console.ForegroundColor;
        var oldBackground = Console.BackgroundColor;
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        Console.Write(message);
        Console.ForegroundColor = oldForeground;
        Console.BackgroundColor = oldBackground;
    }

    public static void WriteLine(
        string message, 
        ConsoleColor foreground,
        ConsoleColor background)
    {
        var oldForeground = Console.ForegroundColor;
        var oldBackground = Console.BackgroundColor;
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        Console.WriteLine(message);
        Console.ForegroundColor = oldForeground;
        Console.BackgroundColor = oldBackground;
    }

}
