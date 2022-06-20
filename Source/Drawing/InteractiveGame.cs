using Mate.Core.Abstractions;
using Mate.Core.Elements.Games;
using Mate.Core.Elements.Rules;
using Mate.Core.Extensions;
using Mate.Core.Notation;
using Sharprompt;
using System.Linq;

namespace Mate.Drawing;


public static class InteractiveGame
{
    public static void RunInteractive()
    {
        IGame game = new Standard<Classical>();
        var options = "";
        while (game.Outcome.HasFlag(Outcome.Running) && options != "quit")
        {
            var player = game.CurrentPlayer ? "White" : "Black";
            var moves = game.AvailableChessMoves();
            options = Prompt.Select(
                $"It is {player} player turn. What would you like to do?",
                new[] { "move", "quit", "history", "score" }
            );

            switch (options)
            {
                case "move":
                    var move = Prompt.Select<string>("What is your move?", moves.Keys);
                    Console.WriteLine($"Your move: {move}");
                    game.ProcessChessMove(move);
                    break;
                case "quit":
                    break;
                case "history":
                    game.MoveEntries.Select((me, i) => $"{i/2 + 1}.{Conversion.MoveToNotation(me.Move)}").
                        ToList().ForEach(Console.WriteLine);
                    break;
                case "score":
                    Console.WriteLine($"The current score is: {game.Score}");
                    break;
            }
        }
    }
}
