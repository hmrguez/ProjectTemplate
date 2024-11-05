namespace GameLogic;

public class GameService
{
    private Cell[,] _board;
    private Cell _tickPlayer = new Cell("X", "yellow");
    private Cell _toePlayer = new Cell("O", "blue");

    private int _playerTurn;
    private SpecialEvent _event = SpecialEvent.None;

    private enum SpecialEvent
    {
        None,
        PlayerWon,
        Draw,
        InvalidMove
    }

    public GameService()
    {
        _board = new[,]
        {
            { Cell.Default, Cell.Default, Cell.Default },
            { Cell.Default, Cell.Default, Cell.Default },
            { Cell.Default, Cell.Default, Cell.Default },
        };
    }


    public Cell[,] GetBoard()
    {
        return _board;
    }

    public void Read(string input)
    {
        var move = int.Parse(input);

        int col = (move - 1) / 3;
        int row = (move - 1) % 3;


        if (row >= 0 && row < 3 && col >= 0 && col < 3 && _board[row, col].Label == ".")
        {
            _board[row, col] = GetCurrentPlayer();
            if (CheckForWin(GetCurrentPlayer()))
            {
                _event = SpecialEvent.PlayerWon;
            }
            else if (IsBoardFull())
            {
                _event = SpecialEvent.Draw;
            }
            else
            {
                _playerTurn++;
            }
        }
        else
        {
            _event = SpecialEvent.InvalidMove;
        }
    }

    public string Write()
    {
        var answer = _event switch
        {
            SpecialEvent.PlayerWon => $"[bold green]{GetCurrentPlayer()}[/] won!!!!",
            SpecialEvent.Draw => "It's a [bold gray]DRAW[/]!",
            SpecialEvent.InvalidMove => "It's an [bold red]INVALIDMOVE[/]!",
            _ => $"[red] {GetCurrentPlayer()} [/]'s turn. Insert a cell number "
        };

        _event = SpecialEvent.None;

        return answer;
    }

    private Cell GetCurrentPlayer()
    {
        return _playerTurn % 2 == 0 ? _tickPlayer : _toePlayer;
    }

    private bool CheckForWin(Cell player)
    {
        // Check rows, columns, and diagonals for a win
        for (int i = 0; i < 3; i++)
        {
            if ((_board[i, 0] == player && _board[i, 1] == player && _board[i, 2] == player) ||
                (_board[0, i] == player && _board[1, i] == player && _board[2, i] == player))
            {
                return true;
            }
        }

        if ((_board[0, 0] == player && _board[1, 1] == player && _board[2, 2] == player) ||
            (_board[0, 2] == player && _board[1, 1] == player && _board[2, 0] == player))
        {
            return true;
        }

        return false;
    }

    private bool IsBoardFull()
    {
        foreach (var cell in _board)
        {
            if (cell.Label == ".")
            {
                return false;
            }
        }

        return true;
    }
}