namespace GameLogic;

public class Cell(string label, string color)
{
    public static Cell Default => new Cell(".", "green");


    public string Label { get; set; } = label;

    public string Color { get; set; } = color;

    public override string ToString()
    {
        return Label;
    }
}