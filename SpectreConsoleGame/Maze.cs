using GameLogic;
using Spectre.Console;

namespace SpectreConsoleGame;

public class Maze(int width, int height, Cell[,] cells)
{
    public int Width { get; set; } = width;
    public int Height { get; set; } = height;
    public Cell[,] Cells { get; set; } = cells;


    public void Draw()
    {
        var table = new Table();
        for (var x = 0; x < Width; x++) table.AddColumn("");

        for (var y = 0; y < Height; y++)
        {
            var row = new List<Markup>();
            for (var x = 0; x < Width; x++)
            {
                var cell = Cells[x, y];
                row.Add(new Markup($"[{cell.Color}]{cell.Label}[/]"));
            }

            table.AddRow(row.ToArray());
        }

        AnsiConsole.Clear();
        AnsiConsole.Write(table);
    }
}