namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;
    private readonly IDictionary<Tile, Player> _tiles;

    public Game()
    {
        _lastPlay = Player.None;
        _tiles = new Dictionary<Tile, Player>();
    }

    public void Play(Player player, Tile tile)
    {
        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }
        
        UpdateLastPlay(player);
        AddPlay(player, tile);
    }

    private void UpdateLastPlay(Player player)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        _lastPlay = player;
    }

    private void AddPlay(Player player, Tile tile)
    {
        if (_tiles.ContainsKey(tile))
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _tiles.Add(tile, player);
    }

    public Player GetWinner()
    {
        if (_tiles.ContainsKey(Tile.Northwest)
            && _tiles.ContainsKey(Tile.North)
            && _tiles.ContainsKey(Tile.Northeast)
            && _tiles[Tile.Northwest] == Player.X
            && _tiles[Tile.Northwest] == Player.X
            && _tiles[Tile.Northwest] == Player.X)
        {
            return Player.X;
        }
        
        if (_tiles.ContainsKey(Tile.West)
            && _tiles.ContainsKey(Tile.Middle)
            && _tiles.ContainsKey(Tile.East)
            && _tiles[Tile.West] == Player.X
            && _tiles[Tile.West] == Player.X
            && _tiles[Tile.West] == Player.X)
        {
            return Player.X;
        }
        
        return Player.None;
    }
}