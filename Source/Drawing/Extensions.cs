using System.Xml.Linq;
using Mate.Core.Abstractions;

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

public static class IllustratorExtensions
{
    private static IReadOnlyDictionary<string, string> GetStyles(
        string styleName,
        XElement styleXML
    )
    {
        return styleXML
            .Descendants(styleName)
            .First()
            .Descendants()
            .ToDictionary(
                item => item.Name.ToString(),
                item => item.Value.Trim(" ".ToCharArray()).Trim("\n".ToCharArray())
            );
    }

    private static IReadOnlyDictionary<string, string> GetColors(
        string paletteName,
        XElement paletteXML
    )
    {
        return paletteXML
            .Descendants("colors")
            .First()
            .Descendants(paletteName)
            .First()
            .Descendants()
            .ToDictionary(
                item => item.Name.ToString(),
                item => item.Value
            );
    }

    private static IReadOnlyDictionary<T, string> DictToEnum<T>(
        this IReadOnlyDictionary<string, string> dictionary
    ) where T : notnull, Enum
    {
        return dictionary
            .ToDictionary(
                item => (T)Enum.Parse(typeof(T), item.Key),
                item => item.Value
            );
    }

    private static IReadOnlyDictionary<TKey, TValue> DictToEnum<TKey, TValue>(
        this IReadOnlyDictionary<string, string> dictionary
    ) where TKey : notnull, Enum
    where TValue : Enum
    {
        return dictionary
            .ToDictionary(
                item => (TKey)Enum.Parse(typeof(TKey), item.Key),
                item => (TValue)Enum.Parse(typeof(TValue), item.Value)
            );
    }

    public static IllustratorStyle LoadFromXML(
        XElement styleSource,
        int margin = 1,
        bool ensureSquare = false
    )
    {
        var pieces = GetStyles("pieces", styleSource).DictToEnum<PieceType>();
        var files = GetStyles("files", styleSource).DictToEnum<Files>();
        var ranks = GetStyles("ranks", styleSource).DictToEnum<Ranks>();
        var pieceColors = GetColors("piece", styleSource).DictToEnum<PieceColor, ConsoleColor>();
        var squareColors = GetColors("square", styleSource).DictToEnum<SquareColor, ConsoleColor>();
        return new IllustratorStyle(
            pieces,
            files,
            ranks,
            pieceColors,
            squareColors,
            margin,
            ensureSquare
        );
    }
}
