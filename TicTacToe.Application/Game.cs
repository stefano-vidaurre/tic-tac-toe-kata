namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;
    private readonly Board _board;

    public Game()
    {
        _lastPlay = Player.None;
        _board = new Board();
    }

    public void Play(Player player, Tile tile)
    {
        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }
        
        UpdateLastPlay(player);
        _board.AddPlay(player, tile);
    }

    private void UpdateLastPlay(Player player)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        _lastPlay = player;
    }

    public Player GetWinner()
    {
        if (HasWonByRow(Player.X))
        {
            return Player.X;
        }
        
        return Player.None;
    }

    private bool HasWonByRow(Player player)
    {
        return HasWonByFirstRow(player) || HasWonBySecondRow(player) || HasWonByThirdRow(player);
    }

    private bool HasWonByThirdRow(Player player)
    {
        return _board.GetTileValue(Tile.Southwest) == player
               && _board.GetTileValue(Tile.South) == player
               && _board.GetTileValue(Tile.Southeast) == player;
    }

    private bool HasWonBySecondRow(Player player)
    {
        return _board.GetTileValue(Tile.West) == player
               && _board.GetTileValue(Tile.Middle) == player
               && _board.GetTileValue(Tile.East) == player;
    }

    private bool HasWonByFirstRow(Player player)
    {
        return _board.GetTileValue(Tile.Northwest) == player
               && _board.GetTileValue(Tile.North) == player
               && _board.GetTileValue(Tile.Northeast) == player;
    }
}