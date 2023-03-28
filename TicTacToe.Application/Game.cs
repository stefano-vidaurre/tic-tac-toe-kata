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
        if (_tiles.GetTileValue(Tile.Northwest) == Player.X
            && _tiles.GetTileValue(Tile.North) == Player.X
            && _tiles.GetTileValue(Tile.Northeast) == Player.X)
        {
            return Player.X;
        }
        
        if (_tiles.GetTileValue(Tile.West) == Player.X
            && _tiles.GetTileValue(Tile.Middle) == Player.X
            && _tiles.GetTileValue(Tile.East) == Player.X)
        {
            return Player.X;
        }
        
        if (_tiles.GetTileValue(Tile.Southwest) == Player.X
            && _tiles.GetTileValue(Tile.South) == Player.X
            && _tiles.GetTileValue(Tile.Southeast) == Player.X)
        {
            return Player.X;
        }
        
        return Player.None;
    }
}