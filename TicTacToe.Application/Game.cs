namespace TicTacToe.Application;

public class Tiles
{
    private readonly IDictionary<Tile, Player> _dictionary;
    
    public Tiles()
    {
        _dictionary = new Dictionary<Tile, Player>();
    }
    
    public void AddPlay(Player player, Tile tile)
    {
        if (_dictionary.ContainsKey(tile))
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _dictionary.Add(tile, player);
    }

    public Player GetTileValue(Tile tile)
    {
        if (_dictionary.ContainsKey(tile))
        {
            return _dictionary[tile];
        }

        return Player.None;
    }
}

public class Game
{
    private Player _lastPlay;
    private readonly Tiles _tiles;

    public Game()
    {
        _lastPlay = Player.None;
        _tiles = new Tiles();
    }

    public void Play(Player player, Tile tile)
    {
        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }
        
        UpdateLastPlay(player);
        _tiles.AddPlay(player, tile);
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
        return HasWonByFirstRow(player) && HasWonBySecondRow(player) && HasWonByThirdRow(player);
    }

    private bool HasWonByThirdRow(Player player)
    {
        return _tiles.GetTileValue(Tile.Southwest) == player
               && _tiles.GetTileValue(Tile.South) == player
               && _tiles.GetTileValue(Tile.Southeast) == player;
    }

    private bool HasWonBySecondRow(Player player)
    {
        return _tiles.GetTileValue(Tile.West) == player
               && _tiles.GetTileValue(Tile.Middle) == player
               && _tiles.GetTileValue(Tile.East) == player;
    }

    private bool HasWonByFirstRow(Player player)
    {
        return _tiles.GetTileValue(Tile.Northwest) == player
               && _tiles.GetTileValue(Tile.North) == player
               && _tiles.GetTileValue(Tile.Northeast) == player;
    }
}