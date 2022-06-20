using Mate.Drawing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.Xml.Linq;


namespace Mate.Drawing;

public static class Loader
{

    public static Command GameMenu()
    {
        var rootCommand = new RootCommand("mate");
        var newGameCommand = new Command(
            "new",
            "Create a new game");
        newGameCommand.SetHandler(() =>
        {
            InteractiveGame.RunInteractive();
        });

        var loadGameCommand = new Command("load",
            "Load an existing game");
        rootCommand.AddCommand(newGameCommand);
        rootCommand.AddCommand(loadGameCommand);
        return rootCommand;
    }

    public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // var illustrator = IllustratorExtensions.LoadFromXML(
        //     XElement.Load(File.OpenText("Styles/small.xml"))
        // );
        services.AddSingleton(GameMenu());
    }

    static int Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();
        
        host.Services.GetRequiredService<Command>().Invoke(args);

        return 0;
    }
}





// illustrator.DrawBoard(
//     new Dictionary<(BoardFile, BoardRank), (PieceType, PieceColor)>()
//     {
//         { (BoardFile.C, BoardRank.Three), (PieceType.Knight, PieceColor.Black) },
//         { (BoardFile.C, BoardRank.Two), (PieceType.Queen, PieceColor.White) }
//     }
// );
