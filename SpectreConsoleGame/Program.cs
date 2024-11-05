using GameLogic;
using Spectre.Console;
using SpectreConsoleGame;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameService = new GameService();
        var maze = new Maze(3, 3, null!);

        while (true)
        {
            maze.Cells = gameService.GetBoard();
            maze.Draw();
            AnsiConsole.WriteLine();
            AnsiConsole.Markup(gameService.Write());
            
            var key = Console.ReadLine();
            gameService.Read(key!);
        }
    }
}


