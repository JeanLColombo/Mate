using Mate.Core.Abstractions;

namespace Mate.Drawing;

public class IllustratorStyle
{

    public static string CentralizePiece(
        string piece,
        int rankSize,
        int fileSize
    )
    {
        var pieceLines = piece.Split("\n");
        var abovePad = (int)Math.Ceiling((rankSize - pieceLines.Length) / 2.0);
        var belowPad = (int)Math.Floor((rankSize - pieceLines.Length) / 2.0);
        var blankLine = new string(' ', fileSize);
        return (
            string.Join("\n", Enumerable.Repeat(blankLine, abovePad)) + 
            "\n" +
            string.Join("\n", pieceLines.Select(
                line =>
                {
                    var beforePad = (int)Math.Ceiling((fileSize - line.Length) / 2.0);
                    var afterPad = (int)Math.Floor((fileSize - line.Length) / 2.0);
                    return line.PadLeft(beforePad + line.Length).PadRight(beforePad + line.Length + afterPad);
                }
            )) +
            "\n" +
            string.Join("\n", Enumerable.Repeat(blankLine, belowPad))
        ).Trim("\n".ToCharArray());
    }

    public IllustratorStyle(
        IReadOnlyDictionary<PieceType, string> pieces,
        IReadOnlyDictionary<Files, string> files,
        IReadOnlyDictionary<Ranks, string> ranks,
        IReadOnlyDictionary<PieceColor, ConsoleColor> pieceColors,
        IReadOnlyDictionary<SquareColor, ConsoleColor> squareColors,
        int margin,
        bool ensureSquareSize
    )
    {
        var icons = pieces.Values.Union(files.Values).Union(ranks.Values).ToArray();
        RankSize = icons.Select(p => p.Split("\n").Length).Max() + 2 * margin;
        FileSize = icons.SelectMany(p => p.Split("\n").Select(r => r.Length)).Max() + 2 * margin;
        FileSize = ensureSquareSize ? Math.Max(RankSize, FileSize) : FileSize;
        RankSize = ensureSquareSize ? Math.Max(RankSize, FileSize) : RankSize;
        Files = files.ToDictionary(
            kvp => kvp.Key,
            kvp => CentralizePiece(kvp.Value, RankSize, FileSize)
        );
        Ranks = ranks.ToDictionary(
            kvp => kvp.Key,
            kvp => CentralizePiece(kvp.Value, RankSize, FileSize)
        );
        Pieces = pieces.ToDictionary(
            kvp => kvp.Key,
            kvp => CentralizePiece(kvp.Value, RankSize, FileSize)
        );
        PieceColors = pieceColors;
        SquareColors = squareColors;
    }

    public IReadOnlyDictionary<PieceType, string> Pieces { get; }
    public IReadOnlyDictionary<PieceColor, ConsoleColor> PieceColors { get; }
    public IReadOnlyDictionary<SquareColor, ConsoleColor> SquareColors { get; }
    public IReadOnlyDictionary<Files, string> Files { get; }
    public IReadOnlyDictionary<Ranks, string> Ranks { get; }
    public int RankSize { get; }
    public int FileSize { get; }

    public void DrawBoard(
        IReadOnlyDictionary<(Files, Ranks), (PieceType, PieceColor)> board
    )
    {
        var allRanks = Enum.GetValues(typeof(Ranks)).Cast<Ranks>();
        var allFiles = Enum.GetValues(typeof(Files)).Cast<Files>();
        allRanks.Reverse().ToList().ForEach(
            rank =>
            {
                var header = Ranks[rank].Split("\n");
                header.Select(
                    (line, i) =>
                    {
                        Console.Write(line);
                        allFiles.Select(
                            file =>
                            {
                                var backgroundColor = (SquareColor)(
                                    ((int)rank + (int)file) % 2);
                                Action writer = board.TryGetValue((file, rank), out var pieceColor) ?
                                    () => ConsoleExtensions.Write(
                                        Pieces[pieceColor.Item1].Split("\n")[i],
                                        PieceColors[pieceColor.Item2],
                                        SquareColors[backgroundColor])
                                     :
                                    () => ConsoleExtensions.Write(
                                        new string(' ', FileSize),
                                        ConsoleColor.Black,
                                        SquareColors[backgroundColor]
                                    );
                                return writer;
                            }
                        ).ToList().ForEach(w => w());
                        Console.WriteLine();
                        return "";
                    }).ToList().ForEach(Console.Write);});
        Enumerable.Range(0, RankSize).ToList().ForEach(
            i =>
            {
                Console.Write(new string(' ', FileSize));
                allFiles.Select(
                    file =>Files[file].Split("\n")[i]
                ).ToList().ForEach(Console.Write);
                Console.Write("\n");
            }
        );
    }

}
